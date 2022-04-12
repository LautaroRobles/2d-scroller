using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TeamManagerSO : ScriptableObject
{
    public TeamManagerEventSO OnTurnStarted;
    public CharacterEventSO OnCharacterSelected;
    public CharacterSetSO Characters;
    [SerializeField] protected int _selectedCharacters;
    [SerializeField] protected bool _enableTeam;
    public virtual void Initialize() { }
    void OnEnable()
    {
        OnTurnStarted.OnEventRaised += StartTurn;
    }
    void OnDisable()
    {
        OnTurnStarted.OnEventRaised -= StartTurn;
    }
    protected abstract void StartTurn(TeamManagerSO team);
}
