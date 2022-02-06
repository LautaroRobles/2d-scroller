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
        if (Input.GetMouseButton(0))
        {
            Pixelart.Play("fire");
        }
    }
}