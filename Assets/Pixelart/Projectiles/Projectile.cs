using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Pixelart))]
public class Projectile : MonoBehaviour
{
    public Texture2D SpriteSheet;
    private Pixelart Pixelart;
    void Start()
    {
        Pixelart = GetComponent<Pixelart>();
        Pixelart.InstantiateSprite(SpriteSheet, 17, 17, new Vector2(0.5f, 0.5f));
        Pixelart.GenerateAnimation("idle", 0, 0, 1f, true);
        Pixelart.Play("idle");
    }

    void Update()
    {

    }
}