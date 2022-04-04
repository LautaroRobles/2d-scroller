using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Fire(Vector3 position, Vector3 direction, float scalar, GameObject projectile)
    {
        if (projectile == null)
            return;

        var firedProjectile = Instantiate(projectile, position, Quaternion.identity);
        var projectileRigidbody = firedProjectile.transform.GetComponent<Rigidbody>();

        var force = direction * scalar;

        projectileRigidbody.AddForce(force, ForceMode.Impulse);
    }
}