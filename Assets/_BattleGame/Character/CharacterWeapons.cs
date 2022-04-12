using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapons : MonoBehaviour
{
    private Character _character;
    private InventorySO _weapons;
    public Transform FirePosition;
    public int SelectedWeapon;
    void Start()
    {
        _character = GetComponentInParent<Character>();
        _weapons = _character.CharacterInventory.Weapons;
    }
    public void NextWeapon()
    {
        SelectedWeapon++;

        if (SelectedWeapon >= _weapons.Count())
        {
            SelectedWeapon = 0;
        }
    }
    public void PrevWeapon()
    {
        SelectedWeapon--;

        if (SelectedWeapon < 0)
        {
            SelectedWeapon = _weapons.Count() - 1;
        }
    }
    public void Fire(Vector3 direction, float force)
    {
        ItemWeaponSO weapon = (ItemWeaponSO)_weapons.GetItem(SelectedWeapon);

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
