using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pixelart))]
public class Fire : MonoBehaviour
{
    public Texture2D FireTexture;
    private Pixelart Pixelart;
    void Start()
    {
        Pixelart = GetComponent<Pixelart>();
        Pixelart.InstantiateSprite(FireTexture, 32, 32, new Vector2(0.5f, 0));
        Pixelart.GenerateAnimation("fire", 0, 11, 0.1f, true);
        Pixelart.Play("fire");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pixelart.Stop();

            foreach (GameObject pixel in Pixelart.Pixels)
            {
                pixel.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}