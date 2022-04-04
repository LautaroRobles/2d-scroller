using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Sprite))]
public class Projectile : MonoBehaviour
{
    private Sprite Sprite;
    void Start()
    {
        Sprite = GetComponent<Sprite>();
        Sprite.GenerateAnimation("idle", 0, 0, 1f, true);
        Sprite.Play("idle");
    }

    void Update()
    {

    }
}