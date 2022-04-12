using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapons : MonoBehaviour
{
    public InventorySO WeaponInventory;
    public Transform FirePosition;
    public int SelectedWeapon;
    public void NextWeapon()
    {
        SelectedWeapon++;

        if (SelectedWeapon >= WeaponInventory.Count())
        {
            SelectedWeapon = 0;
        }
    }
    public void PrevWeapon()
    {
        SelectedWeapon--;

        if (SelectedWeapon < 0)
        {
            SelectedWeapon = WeaponInventory.Count() - 1;
        }
    }
    public void Fire(Vector3 direction, float force)
    {
        ItemWeaponSO weapon = (ItemWeaponSO)WeaponInventory.GetItem(SelectedWeapon);

        var projectile = weapon.ProjectilePool.SpawnObject(FirePosition.position, Quaternion.identity);

        var projectileRigidbody = projectile.GetComponent<Rigidbody>();

        if (projectileRigidbody == null)
        {
            Debug.LogError("Missing Rigidody in Projectile fired");
            return;
        }

        projectileRigidbody.velocity = Vector3.zero;
        projectileRigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
