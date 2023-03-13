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

            gameObject.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * 0.2f * Time.deltaTime);
        }


    }

    

    public void takeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
