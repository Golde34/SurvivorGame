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
        Debug.Log("Entering Attack state");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Attack state");
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
