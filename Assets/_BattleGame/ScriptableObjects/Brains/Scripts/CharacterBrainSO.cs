using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrainSO : ScriptableObject
{
    public virtual void Initialize(Character character, CharacterMovement movement, CharacterWeapons weapon) { }
    public abstract void Think(Character character, CharacterMovement movement, CharacterWeapons weapon);
}
