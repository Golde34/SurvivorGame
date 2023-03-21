using UnityEngine;

public class RangedCreep : Creep
{
    protected bool canShot = true;

    public void SetStat(int level)
    {
        // Initiates the variant's parameters

        this.health = 10 * Mathf.Pow(level, 0.25f);
        this.currentHealth = health;
        this.speed = speedBase * 1.5f * (1 + Mathf.Pow(0.05f, level - 1));
        this.damage = 15 * Mathf.Pow(level, 0.2f);
        this.range = 1;
    }

    public override void Attack(GameObject target)
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
                cannonball.GetComponent<Cannonball>().Destination = target.transform.position;
                cannonball.GetComponent<Cannonball>().Damage = damage;
                cannonball.GetComponent<Cannonball>().ResetTimer();
                cannonball.SetActive(true);

                // Shoot
                canShot = false;
                timer.Duration = 3;
                timer.Run();
            }
        }
    }
}
