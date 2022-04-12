using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class Grenade : MonoBehaviour
{
    public MultiObjectPoolSO ExplosionsPool;
    private Sprite _sprite;
    private Projectile _projectile;
    void Awake()
    {
        _projectile = GetComponent<Projectile>();
        _sprite = GetComponentInChildren<Sprite>();
        _sprite.GenerateAnimation("idle", 0, 0, 0, false);
        _sprite.Play("idle");
    }
    void OnEnable()
    {
        _projectile.OnTimeout += Explode;
        _projectile.OnTimeoutAfterStopping += Explode;
    }
    void OnDisable()
    {
        _projectile.OnTimeout -= Explode;
        _projectile.OnTimeoutAfterStopping -= Explode;
    }
    void Explode()
    {
        ExplosionsPool.SpawnObject(transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
