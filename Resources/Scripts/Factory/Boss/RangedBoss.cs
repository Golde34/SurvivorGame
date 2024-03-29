using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBoss : Boss
{
    protected bool canShot = true;

    public void SetStat(int level)
    {
        // Initiates the variant's parameters

        this.health = 10 * Mathf.Pow(level, 0.25f) * 3;
        currentHealth = health;
        this.speed = speedBase * 1.5f * (1 + Mathf.Pow(0.05f, level - 1));
        this.damage = 30 * Mathf.Pow(level, 0.2f);
        this.range = 1.5f;
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
            GameObject fire = ObjectPool.SharedInstance.GetPooledObject("Fire");
            if (fire != null)
            {
                fire.transform.position = gameObject.transform.position;
                fire.GetComponent<Cannonball>().Destination = target.transform.position;
                fire.GetComponent<Cannonball>().Damage = damage;
                fire.GetComponent<Cannonball>().ResetTimer();
                fire.SetActive(true);

                // Shoot
                canShot = false;
                timer.Duration = 3;
                timer.Run();
            }
        }
    }
}
