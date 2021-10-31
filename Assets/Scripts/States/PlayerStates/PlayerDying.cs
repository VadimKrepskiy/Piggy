using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDying : State<Player>
{
    public PlayerDying(Player player, StateMachine<Player> stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        Object.Destroy(_character.gameObject);
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        
    }
}
