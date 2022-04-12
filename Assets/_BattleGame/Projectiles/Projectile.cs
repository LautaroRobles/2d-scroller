using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Rigidbody Rigidbody;
    public float Timeout;
    public float TimeoutAfterStopping;
    public float DespawnSpeedEpsilon = 0.3f;
    public bool DisableAfterTimeout;
    private float TimeOnEnable;
    private float TimeOnStopping;

    //Events
    public event Action OnSpawn;
    public event Action OnTimeout;
    public event Action OnTimeoutAfterStopping;
    public void OnEnable()
    {
        Rigidbody = GetComponent<Rigidbody>();
        TimeOnEnable = Time.time;
        TimeOnStopping = Time.time;

        Rigidbody.velocity = Vector3.zero;

        OnSpawn?.Invoke();
    }
    void Update()
    {
        if (Timeout >= 0)
            TriggerTimeout();
        if (TimeoutAfterStopping >= 0)
            TriggerTimeOutAfterStopping();
    }
    void TriggerTimeout()
    {
        // Disable
        var currentTime = Time.time;
        if (Mathf.Abs(currentTime - TimeOnEnable) > Timeout)
        {
            OnTimeout?.Invoke();
            if (DisableAfterTimeout)
                gameObject.SetActive(false);
        }
    }
    void TriggerTimeOutAfterStopping()
    {
        var speed = Rigidbody.velocity.magnitude;

        if (speed > DespawnSpeedEpsilon)
            TimeOnStopping = Time.time;

        var currentTime = Time.time;
        if (Mathf.Abs(currentTime - TimeOnStopping) > TimeoutAfterStopping)
        {
            OnTimeoutAfterStopping?.Invoke();
            if (DisableAfterTimeout)
                gameObject.SetActive(false);
        }
    }
}