using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> where T : Character
{
    protected T _character;
    protected StateMachine<T> _stateMachine;

    public State(T character, StateMachine<T> stateMachine)
    {
        _character = character;
        _stateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
