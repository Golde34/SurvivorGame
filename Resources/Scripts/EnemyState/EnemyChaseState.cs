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
        Debug.Log("Entering Chase state");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Chase state");
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
