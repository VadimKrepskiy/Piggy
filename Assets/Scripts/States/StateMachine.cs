using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> : MonoBehaviour where T : Character
{
    protected T _character;
    protected State<T> _currentState;

    void Update()
    {
        _currentState.Update();
    }

    public void SetState(State<T> state)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}


