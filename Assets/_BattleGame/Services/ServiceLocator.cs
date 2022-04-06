using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    public static ServiceLocator Main { get; private set; }
    public Shooter Shooter { get; private set; }
    public ObjectPooler ObjectPooler { get; private set; }
    public SceneControl SceneControl { get; private set; }
    private void Awake()
    {
        if (Main != null && Main != this)
        {
            Destroy(gameObject);
            return;
        }
        Main = this;
        DontDestroyOnLoad(this);

        // Services injections
        Shooter = GetComponentInChildren<Shooter>();
        ObjectPooler = GetComponentInChildren<ObjectPooler>();
        SceneControl = GetComponentInChildren<SceneControl>();
    }
}
