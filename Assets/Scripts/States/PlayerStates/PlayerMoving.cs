using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : State<Player>
{
    public PlayerMoving(Player player, StateMachine<Player> stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        if (!_character.OnMove || !_character.IsCanMove)
            _stateMachine.SetState(new PlayerStanding(_character, _stateMachine));
        else _character.Move();
    }
}
