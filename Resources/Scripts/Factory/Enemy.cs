using Assets.Resources.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public abstract class Enemy : MonoBehaviour
{
    protected float health;
    protected float currentHealth;
    protected float speed;
    protected float damage;
    protected float heal;
    protected int Diamond;
    protected float range;
    protected int level;

    protected Timer timer;

    protected float speedBase = 2; 
    protected GameObject target = null;
    protected GameObject realTarget = null;

    private float nextTimeToDealDamage = 0;
    public float timeBetweenEnemyAttack = 5;

    //public float separationRadius = 0.5f; // the radius within which to apply separation
    //public float separationWeight = 0.1f; // the weight to give to separation force
    private Rigidbody2D rb2d;

    public enum EnemyType
    {
        Boss, Creep
    }

    public abstract EnemyType GetEnemyType();
    protected abstract void Attack(GameObject target);

    // Start is called before the first frame update
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Hero") != null && GameObject.Find("King") != null)
        {
            target = GameObject.FindGameObjectWithTag("Hero");
            realTarget = GameObject.Find("King");

            if (Vector2.Distance(transform.position, target.transform.position) <= range)
            {
                if (Time.time >= nextTimeToDealDamage)
                {
                    Attack(realTarget);
                    nextTimeToDealDamage = Time.time + timeBetweenEnemyAttack;
                }
            }
            else
            {
                transform.Translate((target.transform.position - transform.position) * Time.deltaTime * speed * 0.2f);
            }
        }


    }

    //private void FixedUpdate()
    //{
    //    Vector2 separationForce = Vector2.zero;
    //    int nearbyEnemies = 0;

    //    // Find all enemies within separation radius
    //    Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, separationRadius, LayerMask.GetMask("Enemy"));
    //    List<Enemy> nearbyEnemiesList = new List<Enemy>();
    //    foreach (Collider2D collider in nearbyColliders)
    //    {
    //        nearbyEnemiesList.Add(collider.gameObject.GetComponent<Enemy>());
    //        nearbyEnemies++;
    //    }

    //    // Calculate separation force
    //    foreach (Enemy enemy in nearbyEnemiesList)
    //    {
    //        Vector2 offset = rb2d.position - enemy.rb2d.position;
    //        float sqrDistance = offset.sqrMagnitude;
    //        if (sqrDistance > 0f)
    //        {
    //            separationForce += offset.normalized / sqrDistance;
    //        }
    //    }

    //    // Apply separation force
    //    if (nearbyEnemies > 0)
    //    {
    //        separationForce /= nearbyEnemies;
    //        rb2d.AddForce(separationForce * separationWeight);
    //    }
    //}

    public void takeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
