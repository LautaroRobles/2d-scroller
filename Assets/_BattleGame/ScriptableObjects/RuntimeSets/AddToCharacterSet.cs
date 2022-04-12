using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCharacterSet : MonoBehaviour
{
    public CharacterSetSO CharacterSet;
    public Character Character;
    void OnEnable()
    {
        CharacterSet.Add(Character);
    }
    void OnDisable()
    {
        CharacterSet.Remove(Character);
    }
}