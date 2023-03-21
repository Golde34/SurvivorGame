using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Wand : MonoBehaviour, IWeapon
{
    public string Name => "Wand";
    public int Damage { get; set; }
    public int FitPoint { get; set; }
    public Vector3 WeaponPoint { get; set; }

    protected bool canShot = true;
    Timer timer;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
    }
    public void Attack()
    {
        StartCoroutine(MoveBackAndForth());
    }

    IEnumerator MoveBackAndForth()
    {
        if (!canShot && timer.Finished)
        {
            canShot = true;
        }
        if (canShot)
        {
            gameObject.transform.localPosition = new Vector3(0.3f, -0.1f, 1.0f);
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 270));
            Fire();
            yield return new WaitForSeconds(0.3f);
            gameObject.transform.localPosition = new Vector3(0.2f, 0.1f, 1.0f);
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            // Shoot
            canShot = false;
            timer.Duration = 3;
            timer.Run();
        }
    }

    private void Fire()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, 5f, LayerMask.GetMask("Enemy"));
        if (hitEnemies.Length > 0)
        {
            GameObject target = findClosestEnemy(hitEnemies);
            GameObject thunder = ObjectPool.SharedInstance.GetPooledObject("Thunderbolt");
            if (thunder != null)
            {
                thunder.transform.position = gameObject.transform.position;
                thunder.GetComponent<Thunderbolt>().Target = target;
                thunder.GetComponent<Thunderbolt>().Damage = Damage;
                thunder.GetComponent<Thunderbolt>().ResetTimer();
                thunder.SetActive(true);
            }
        }
    }

    private GameObject findClosestEnemy(Collider2D[] close)
    {
        GameObject closestEnemy = close[0].gameObject;
        float closestDistance = float.MaxValue;
        bool first = true;

        for (int i = 0; i < close.Length; i++)
        {
            float distance = Vector3.Distance(close[i].gameObject.transform.position, gameObject.transform.position);
            if (first)
            {
                closestDistance = distance;

                first = false;
            }
            else if (distance < closestDistance)
            {
                closestEnemy = close[i].gameObject;
                closestDistance = distance;
            }
        }
        return closestEnemy;
    }
}
