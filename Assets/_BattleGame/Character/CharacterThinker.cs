using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterThinker : MonoBehaviour
{
    public Character Character;
    public CharacterWeapons Weapon;
    public CharacterMovement Movement;
    public CharacterBrainSO Brain;
    void Start()
    {
        Brain.Initialize(Character, Movement, Weapon);
    }
    void Update()
    {
        Brain.Think(Character, Movement, Weapon);
    }
}
