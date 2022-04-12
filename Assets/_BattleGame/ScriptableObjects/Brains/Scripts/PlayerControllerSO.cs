using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Brains/PlayerController")]
public class PlayerControllerSO : CharacterBrainSO
{
    private PlayerInputActions _playerInput;
    public float Gravity;
    public float Speed;
    public float JumpSpeed;
    public float MaxMoveAmmount;
    public override void Initialize(Character character)
    {
        _playerInput = new PlayerInputActions();
        _playerInput.Player.Enable();
    }
    public override void Think(Character character)
    {
        if (!character.CharacterStateManager.EnableBrain)
            return;

        var movement = character.CharacterMovement;
        var weapon = character.CharacterWeapons;

        movement.Gravity = Gravity;
        movement.JumpSpeed = JumpSpeed;
        movement.Speed = Speed;

        MovementControl(movement);
        WeaponControl(weapon);
    }
    private void MovementControl(CharacterMovement movement)
    {
        if (_playerInput.Player.Jump.triggered)
            movement.Jump();

        Vector2 input = _playerInput.Player.Move.ReadValue<Vector2>();
        movement.Move(input.x);
    }
    private void WeaponControl(CharacterWeapons weapon)
    {
        if (_playerInput.Player.NextWeapon.triggered)
            weapon.NextWeapon();
        if (_playerInput.Player.PrevWeapon.triggered)
            weapon.PrevWeapon();
        if (_playerInput.Player.Fire.triggered)
            weapon.Fire(new Vector3(1, 1, 0), 5f);
    }
}
