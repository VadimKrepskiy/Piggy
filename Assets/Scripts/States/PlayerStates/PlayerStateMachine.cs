using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStateMachine : StateMachine<Player>
{
    void Start()
    {
        _character = GetComponentInParent<Player>();
        _currentState = new PlayerStanding(_character, this);
    }
}
