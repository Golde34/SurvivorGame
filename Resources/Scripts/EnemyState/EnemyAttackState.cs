using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        enemy.Attack();
        if (!enemy.IsPlayerInRange())
        {
            enemy.TransitionToState(new EnemyChaseState(enemy));
        }
    }
}
