using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventorySystem/Items/Weapon")]
public class ItemWeaponSO : ItemSO
{
    // Leave negative for infinite ammo
    [Header("Ammunition")]
    public int AmmoPerTurn;
    public int AmmoPerGame;
    [Header("Projectile Stats")]
    public float BaseDamage;
    [Header("Activate Stats")]
    public float ActivateTime;
    public bool ActivateOnHit;
    public ObjectPoolSO ProjectilePool;
    public GameObject FireProjectile(Vector3 position, Vector3 direction, float power)
    {
        var projectileObject = ProjectilePool.SpawnObject(position, Quaternion.identity);
        var projectile = projectileObject.GetComponent<Projectile>();

        return projectileObject;
    }
}
