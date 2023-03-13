using Assets.Resources.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCreep : Creep
{
    protected bool canShot = true;

    public void SetStat(int level)
    {
        // Initiates the variant's parameters
        this.speed = speedBase * (1 + Mathf.Pow(0.05f, level - 1));

        this.health = 10 * Mathf.Pow(level, 0.25f);
        this.damage = 10;
        this.range = 1;
        currentHealth = health;
    }

    protected override void Attack(GameObject target)
    {
        if (!canShot && timer.Finished)
        {
            canShot = true;
        }
        if (canShot)
        {
            GameObject cannonball = ObjectPool.SharedInstance.GetPooledObject("Cannonball");
            if (cannonball != null)
            {
                cannonball.transform.position = gameObject.transform.position;
                cannonball.GetComponent<Cannonball>().ResetTimer();
                cannonball.SetActive(true);

                // Shoot
                canShot = false;
                timer.Duration = 1;
                timer.Run();
            }
        }
    }
}
