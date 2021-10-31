using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : State<Enemy>
{
    public EnemyAttacking(Enemy enemy, StateMachine<Enemy> stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        _character.Attack();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if(_character.IsDamaged)
            _stateMachine.SetState(new EnemyDying(_character, _stateMachine));
        if (!_character._visibilityController.IsPlayerDetected || !_character.IsPlayerFound)
            _stateMachine.SetState(new EnemyPatrolling(_character, _stateMachine));
    }
}
