using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCreep : Creep
{
    public void SetStat(int level)
    {
        // Initiates the variant's parameters
        this.speed = speedBase * (1 + Mathf.Pow(0.05f, level - 1));

        this.health = 10 * Mathf.Pow(level, 0.25f);
        this.range = 0.3f;
        this.currentHealth = health;
    }

    void Awake()
    {

    }

    protected override void Attack(GameObject target)
    {
        target.GetComponent<IHero>().takeDamage(10);
    }
}
