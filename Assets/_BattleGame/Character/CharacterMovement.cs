using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController Controller;
    [HideInInspector] public float Gravity;
    [HideInInspector] public float Speed;
    [HideInInspector] public float JumpSpeed;
    private Vector3 _moveDirection = Vector3.zero;
    void Update()
    {
        ApplyGravity();
        ApplyStoppers();

        Controller.Move(_moveDirection * Time.deltaTime);
    }
    void ApplyGravity()
    {
        _moveDirection.y -= Gravity * Time.deltaTime;
    }
    void ApplyStoppers()
    {
        _moveDirection.x -= Speed * Mathf.Sign(_moveDirection.x) * Time.deltaTime;
    }
    public void Jump()
    {
        if (!Controller.isGrounded)
            return;

        _moveDirection.y = JumpSpeed;
    }
    public void Move(float direction)
    {
        _moveDirection.x = direction * Speed;
    }
}
