using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<TeamManagerSO> Teams;
    private int _teamTurn;
    public TeamManagerEventSO OnTurnStarted;
    void Start()
    {
        foreach (TeamManagerSO team in Teams)
        {
            team.Initialize();
        }
        StartTurn();
    }
    void Update()
    {

    }
    private void StartTurn()
    {
        var team = Teams[_teamTurn];
        OnTurnStarted.RaiseEvent(team);
    }
    private void EndTurn()
    {
        _teamTurn++;
    }
}
