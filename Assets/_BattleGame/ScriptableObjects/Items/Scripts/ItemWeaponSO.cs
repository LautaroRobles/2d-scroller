using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemWeapon")]
public class ItemWeaponSO : ItemSO
{
    public ObjectPoolSO ProjectilePool;
    public int AmmoPerTurn;
}
