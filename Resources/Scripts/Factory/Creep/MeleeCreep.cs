using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCreep : Creep
{
    protected bool canShot = true;

    public void SetStat(int level)
    {
        // Initiates the variant's parameters
        this.speed = speedBase * (1 + Mathf.Pow(0.05f, level - 1));

        this.health = 10 * Mathf.Pow(level, 0.25f);
        this.range = 0.2f;
        this.currentHealth = health;
    }

    void Awake()
    {

    }

    public override void Attack(GameObject target)
    {
        if (!canShot && timer.Finished)
        {
            canShot = true;
        }
        if (canShot)
        {
            target.GetComponent<IHero>().TakeDamage(10);

            // Shoot
            canShot = false;
            timer.Duration = 3;
            timer.Run();
        }
    }
}
