using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pixelart))]
public class Player : MonoBehaviour
{
    public Texture2D SpriteSheet;
    private Pixelart Pixelart;
    public GameObject Projectile;
    public bool Dead = false;
    // Start is called before the first frame update
    void Start()
    {
        Pixelart = GetComponent<Pixelart>();
        Pixelart.InstantiateSprite(SpriteSheet, 32, 32, new Vector2(0.5f, 0f));
        Pixelart.GenerateAnimation("idle", 2, 2, 0.1f, false);
        Pixelart.GenerateAnimation("run", 13, 16, 0.1f, true);
        Pixelart.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
            return;

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            Pixelart.Play("run");
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            Pixelart.Play("idle");
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pixelart.Stop();
            Dead = true;

            foreach (GameObject pixel in Pixelart.Pixels)
            {
                pixel.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var weapon = GetComponent<Weapon>();

            var direction = new Vector3(0.5f, 0.5f, 0f);

            weapon.Fire(transform.position, direction, 20, Projectile);
        }
    }
}
