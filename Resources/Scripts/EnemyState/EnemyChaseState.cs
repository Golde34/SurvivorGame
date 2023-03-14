using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy) : base(enemy)
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
        enemy.Chase();
        if (enemy.IsPlayerInRange())
        {
            enemy.TransitionToState(new EnemyAttackState(enemy));
        }
    }
}
