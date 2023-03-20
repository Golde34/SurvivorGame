using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class King : MonoBehaviour, IHero
{
    public float Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public float Speed { get; set; }
    public float DSpeed { get; set; }
    public float Range { get; set; }
    public float currentHealth { get; set; }
    public IWeapon Weapon { get; set; }

    private Hero _heroFlyweight;

    private float nextTimeToDealDamage = 0;
    public float timeBetweenEnemyAttack = 3;
    public Vector2 speed1 = new Vector2(0, 2f);
    public Vector2 speed2 = new Vector2(2f, 0);
    Vector2 localScale;
    GameObject target;
    int diamonds = 0;

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Hero");
        gameObject.transform.position = target.transform.position;
    }

    public King()
    {
        _heroFlyweight = HeroFlyweightFactory.GetFlyWeight("King");
    }

    public void Attack(Collider2D[] hitEnemies)
    {
        if (Time.time >= nextTimeToDealDamage)
        {
            _heroFlyweight.Attack(hitEnemies);
            nextTimeToDealDamage = Time.time + DSpeed;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = _heroFlyweight.TakeDamage(amount, currentHealth);
    }

    public void RegenHealth(float health)
    {
        currentHealth = _heroFlyweight.RegenHealth(health, currentHealth);
    }

    public void CollectDiamond(int value)
    {
        diamonds = _heroFlyweight.CollectDiamond(value, diamonds); 
    }

    public int UseDiamonds()
    {
        return diamonds;
    }

    public void Move()
    {
        _heroFlyweight.Move(target, gameObject);
    }
}
