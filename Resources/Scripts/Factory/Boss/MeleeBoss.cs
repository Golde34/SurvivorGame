using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBoss : Boss
{
    public void SetStat(int level)
    {
        // Initiates the variant's parameters

        this.speed = speedBase * (1 + Mathf.Pow(0.05f, level - 1));
        this.health = 10 * Mathf.Pow(level, 0.25f) * 3;
        this.range = 0.5f;
        currentHealth = health;
    }

    void Awake()
    {

    }

    protected override void Attack(GameObject target)
    {
        target.GetComponent<IHero>().takeDamage(20);
    }
}
