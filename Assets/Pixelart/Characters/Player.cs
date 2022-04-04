using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class Player : MonoBehaviour
{
    private Sprite Sprite;
    public GameObject Projectile;
    public bool Dead = false;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<Sprite>();
        Sprite.GenerateAnimation("idle", 2, 2, 0.1f, false);
        Sprite.GenerateAnimation("run", 13, 16, 0.1f, true);
        Sprite.Play("idle");
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
            Sprite.Play("run");
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            Sprite.Play("idle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var weapon = GetComponent<Weapon>();

            var direction = new Vector3(0.5f, 0.5f, 0f);

            weapon.Fire(transform.position, direction, 10, Projectile);
        }
    }
}
