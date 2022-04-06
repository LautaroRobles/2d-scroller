using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class Grenade : MonoBehaviour
{
    private Sprite Sprite;
    private Projectile Projectile;
    void Awake()
    {
        Projectile = GetComponent<Projectile>();
        Sprite = GetComponentInChildren<Sprite>();
        Sprite.GenerateAnimation("idle", 0, 0, 0, false);
        Sprite.Play("idle");
    }
    void OnEnable()
    {
        Projectile.OnTimeout += Explode;
        Projectile.OnTimeoutAfterStopping += Explode;
    }
    void OnDisable()
    {
        Projectile.OnTimeout -= Explode;
        Projectile.OnTimeoutAfterStopping -= Explode;
    }
    void Explode()
    {
        var ObjectPooler = ServiceLocator.Main.ObjectPooler;
        var explosionPosition = new Vector3(transform.position.x, 0, transform.position.z);
        ObjectPooler.SpawnFromPool("explosion-5", explosionPosition, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
