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
    protected Vector2 localScale;

    private DiamondSpawner diamondSpawner;
    private float nextTimeToDealDamage = 0;
    public float timeBetweenEnemyAttack = 5;

    private EnemyState currentState;

    //public float separationRadius = 0.5f; // the radius within which to apply separation
    //public float separationWeight = 0.1f; // the weight to give to separation force
    private Rigidbody2D rb2d;

    public enum EnemyType
    {
        Boss, Creep
    }

    public abstract EnemyType GetEnemyType();
    public abstract void Attack(GameObject target);

    // Start is called before the first frame update
    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        rb2d = GetComponent<Rigidbody2D>();

        diamondSpawner = gameObject.AddComponent<DiamondSpawner>();
        TransitionToState(new EnemyChaseState(this));
    }

    public void TransitionToState(EnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void Attack()
    {
        realTarget = GameObject.Find("King");
        if (Time.time >= nextTimeToDealDamage)
        {
            Attack(realTarget);
            nextTimeToDealDamage = Time.time + timeBetweenEnemyAttack;
        }
    }

    public void Chase()
    {
        target = GameObject.FindGameObjectWithTag("Hero");

        // Enemy faces toward the main character while chasing
        if (target.transform.position.x < gameObject.transform.position.x)
        {
            localScale = gameObject.transform.localScale;
            if (localScale.x > 0)
            {
                localScale.x *= -1;
                this.gameObject.transform.localScale = localScale;
            }
        }
        else if (target.transform.position.x > gameObject.transform.position.x)
        {
            localScale = gameObject.transform.localScale;
            if (localScale.x < 0)
            {
                localScale.x *= -1;
                this.gameObject.transform.localScale = localScale;
            }
        }

        transform.Translate((target.transform.position - transform.position) * Time.deltaTime * speed * 0.2f);
    }

    public bool IsPlayerInRange()
    {
        if (GameObject.FindGameObjectWithTag("Hero") != null && GameObject.Find("King") != null)
        {
            target = GameObject.FindGameObjectWithTag("Hero");
            realTarget = GameObject.Find("King");

            if (Vector2.Distance(transform.position, target.transform.position) <= range)
            {
                return true;
            }
        }
        return false;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
