using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : Enemy
{
    /// <summary>
    /// Returns the enemy type while inheriting from Enemy class
    /// </summary>
    /// <returns></returns>
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Creep;
    }

    protected override void Attack(GameObject target)
    {
        
    }
}
