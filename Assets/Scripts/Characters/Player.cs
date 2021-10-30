using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerStateMachine _stateMachine;

    private void Awaken()
    {
        _stateMachine = GetComponent<PlayerStateMachine>();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
