using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerStateMachine _stateMachine;

    protected override void Awaken()
    {
        base.Awaken();
        _stateMachine = GetComponent<PlayerStateMachine>();
    }

    protected override void Start()
    {
        base.Start();
    }
}
