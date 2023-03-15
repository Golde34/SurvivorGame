using System;
using TMPro;
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
   

    private float nextTimeToDealDamage = 0;
    public float timeBetweenEnemyAttack = 3;
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Hero");
        gameObject.transform.position = target.transform.position;
    }

    public void Attack(Collider2D[] hitEnemies)
    {
        if (Time.time >= nextTimeToDealDamage)
        {
            Debug.Log("Attack at: " + Time.time);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag.Equals("Enemy"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(Damage);
                }
            }
            nextTimeToDealDamage = Time.time + timeBetweenEnemyAttack;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Current Heath: " + currentHealth+"/" + Health + "; Loss: " + amount);

        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }

    public IWeapon UseWeapon(string weaponString)
    {
        //this.Weapon = new Sword();
        //IWeaponFactory factory = new SwordFactory();
        //GameObject target = GameObject.FindGameObjectWithTag("Hero");
        //IWeapon weapon = factory.CreateWeapon(target.gameObject.transform);

        CharacterStateEvent weaponSelect = new CharacterStateEvent();
        IWeapon weapon = weaponSelect.WeaponState(weaponString, this.Weapon);
        return weapon;
    }

    public void RegenHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > Health)
        {
            currentHealth = Health;
        }
        Debug.Log("Heath after regen: " + currentHealth);
    }

    public void CollectDiamond(int value)
    {
        Debug.Log("Gain Diamond");
    }
}
