using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterEventSO OnCharacterSelected;
    public bool EnableBrain;
    void OnEnable()
    {
        OnCharacterSelected.OnEventRaised += Selected;
    }
    void OnDisable()
    {
        OnCharacterSelected.OnEventRaised -= Selected;
    }
    void Selected(Character character)
    {
        EnableBrain = character == this;
    }
}
