using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooter : MonoBehaviour
{
    public void Fire(string projectileTag, Vector3 position, Vector3 direction, float forceScalar)
    {
        var ObjectPooler = ServiceLocator.Main.ObjectPooler;

        var projectile = ObjectPooler.SpawnFromPool(projectileTag, position, Quaternion.identity);

        var rigidbody = projectile.GetComponent<Rigidbody>();

        rigidbody.AddForce(direction * forceScalar, ForceMode.Impulse);
    }
}

