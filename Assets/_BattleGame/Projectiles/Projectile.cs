using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Timeout;
    public float TimeoutAfterStopping;
    public float DespawnSpeedEpsilon = 0.3f;
    public bool DisableAfterTimeout;
    private float _timeOnEnable;
    private float _timeOnStopping;

    //Events
    public event Action OnSpawn;
    public event Action OnTimeout;
    public event Action OnTimeoutAfterStopping;
    public void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _timeOnEnable = Time.time;
        _timeOnStopping = Time.time;

        _rigidbody.velocity = Vector3.zero;

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
        if (Mathf.Abs(currentTime - _timeOnEnable) > Timeout)
        {
            OnTimeout?.Invoke();
            if (DisableAfterTimeout)
                gameObject.SetActive(false);
        }
    }
    void TriggerTimeOutAfterStopping()
    {
        var speed = _rigidbody.velocity.magnitude;

        if (speed > DespawnSpeedEpsilon)
            _timeOnStopping = Time.time;

        var currentTime = Time.time;
        if (Mathf.Abs(currentTime - _timeOnStopping) > TimeoutAfterStopping)
        {
            OnTimeoutAfterStopping?.Invoke();
            if (DisableAfterTimeout)
                gameObject.SetActive(false);
        }
    }
}