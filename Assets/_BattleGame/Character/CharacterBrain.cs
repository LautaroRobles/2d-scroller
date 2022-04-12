using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrain : MonoBehaviour
{
    private Character _character;
    public CharacterBrainSO PluggableBrain;
    void Start()
    {
        _character = GetComponentInParent<Character>();
        PluggableBrain.Initialize(_character);
    }
    void Update()
    {
        PluggableBrain.Think(_character);
    }
}
