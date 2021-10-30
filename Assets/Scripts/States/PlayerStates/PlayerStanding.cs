using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStanding : State<Player>
{

    public PlayerStanding(Player player, StateMachine<Player> stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if(_character.OnMove)
        {
            _stateMachine.SetState(new PlayerMoving(_character, _stateMachine));
        }
    }
}
