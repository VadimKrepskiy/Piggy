using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDying : State<Enemy>
{
    public EnemyDying(Enemy enemy, StateMachine<Enemy> stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        _character.Pollute();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }

}
