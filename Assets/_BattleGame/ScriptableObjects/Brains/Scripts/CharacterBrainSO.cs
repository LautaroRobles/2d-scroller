using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrainSO : ScriptableObject
{
    public virtual void Initialize(Character character) { }
    public abstract void Think(Character character);
}
