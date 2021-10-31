using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStateMachine : StateMachine<Enemy>
{
    void Start()
    {
        _character = GetComponentInParent<Enemy>();
        _currentState = new EnemyPatrolling(_character, this);
    }
}
