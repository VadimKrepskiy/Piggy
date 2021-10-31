using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStanding : State<Player>
{

    public PlayerStanding(Player character, StateMachine<Player> stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if(_character.IsDamaged)
            _stateMachine.SetState(new PlayerDying(_character, _stateMachine));
        else if (_character.OnMove)
        {
            _stateMachine.SetState(new PlayerMoving(_character, _stateMachine));
        }
        else if(_character.IsThrownBomb)
            _stateMachine.SetState(new PlayerBombThrowing(_character, _stateMachine));
    }
}
