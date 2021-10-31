using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : State<Enemy>
{
    private string[] _route;
    private int _indexCurrentDestination;

    public EnemyPatrolling(Enemy enemy, StateMachine<Enemy> stateMachine) : base(enemy, stateMachine) { }
    
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        _character.CheckDestination();
        _character.Move();
    }

}
