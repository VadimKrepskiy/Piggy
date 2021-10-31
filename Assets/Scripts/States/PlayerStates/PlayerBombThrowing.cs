using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombThrowing : State<Player>
{
    public PlayerBombThrowing(Player player, StateMachine<Player> stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        _character.ThrowBomb();
        _stateMachine.SetState(new PlayerStanding(_character, _stateMachine));
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (_character.IsDamaged)
            _stateMachine.SetState(new PlayerDying(_character, _stateMachine));
    }
}
