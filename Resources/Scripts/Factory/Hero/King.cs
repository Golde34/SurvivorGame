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

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Hero");
        gameObject.transform.position = target.transform.position;
    }

    public void Attack(Collider2D[] hitEnemies)
    {
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag.Equals("Enemy"))
            {
                Debug.Log("hit enemy");
                enemy.GetComponent<Enemy>().TakeDamage(Damage);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        Debug.Log("Current Heath: " + currentHealth+"/" + Health + "; Loss: " + amount);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void UseWeapon()
    {
        this.Weapon = new Spear();
        IWeaponFactory factory = new SpearFactory();
        GameObject target = GameObject.FindGameObjectWithTag("Hero");
        Debug.Log("position: " + target.gameObject.transform.position.x);
        factory.CreateWeapon(target.gameObject.transform);
    }
}
