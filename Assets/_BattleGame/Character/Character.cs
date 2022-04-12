using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // this class works as a Service Locator for each part of a Character Body
    public CharacterBrain CharacterBrain;
    public CharacterMovement CharacterMovement;
    public CharacterWeapons CharacterWeapons;
    public CharacterRender CharacterRender;
    public CharacterStateManager CharacterStateManager;
    public CharacterInventory CharacterInventory;
    void Awake()
    {
        CharacterBrain = GetComponentInChildren<CharacterBrain>();
        CharacterMovement = GetComponentInChildren<CharacterMovement>();
        CharacterWeapons = GetComponentInChildren<CharacterWeapons>();
        CharacterRender = GetComponentInChildren<CharacterRender>();
        CharacterStateManager = GetComponentInChildren<CharacterStateManager>();
        CharacterInventory = GetComponentInChildren<CharacterInventory>();
    }
}
