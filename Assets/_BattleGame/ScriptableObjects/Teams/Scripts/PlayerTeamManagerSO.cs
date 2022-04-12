using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Teams/PlayerTeamManager")]
public class PlayerTeamManagerSO : TeamManagerSO
{
    private PlayerInputActions _input;
    public override void Initialize()
    {
        _input = new PlayerInputActions();
        _input.CharacterSelect.Enable();
        _input.CharacterSelect.ChangeCharacter.performed += ChangeCharacter;
    }
    protected override void StartTurn(TeamManagerSO team)
    {
        _enableTeam = (team == this);
    }
    private void ChangeCharacter(InputAction.CallbackContext context)
    {
        if (!_enableTeam)
            return;
        if (Characters.Count() < 0)
            return;

        int nextCharacter = Mathf.CeilToInt(context.ReadValue<float>());

        _selectedCharacters += nextCharacter;

        if (_selectedCharacters >= Characters.Count())
        {
            _selectedCharacters = 0;
        }

        if (_selectedCharacters < 0)
        {
            _selectedCharacters = Characters.Count() - 1;
        }

        var character = Characters.GetItem(_selectedCharacters);

        OnCharacterSelected.RaiseEvent(character);
    }

}
