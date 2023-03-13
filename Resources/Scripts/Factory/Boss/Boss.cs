using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    /// <summary>
    /// Returns the enemy type while inheriting from Enemy class
    /// </summary>
    /// <returns></returns>
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Boss;
    }

    protected override void Attack(GameObject target)
    {
        
    }
}
