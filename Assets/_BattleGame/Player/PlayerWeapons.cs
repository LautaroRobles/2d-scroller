using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public float Force;
    public Transform Transform;
    public string Weapon = "cannon";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Shooter = ServiceLocator.Main.Shooter;
            var direction = new Vector3(0.5f, 0.5f, 0);

            Shooter.Fire(Weapon, Transform.position, direction, Force);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Weapon == "cannon")
            {
                Weapon = "grenade";
            }
            else
            {
                Weapon = "cannon";
            }
        }
    }
}
