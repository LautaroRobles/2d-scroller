using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class Cannon : MonoBehaviour
{
    private Sprite Sprite;
    private Projectile Projectile;
    void Awake()
    {
        Sprite = GetComponentInChildren<Sprite>();
        Sprite.GenerateAnimation("idle", 0, 0, 0, false);
        Sprite.Play("idle");
    }

}