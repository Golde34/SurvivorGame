using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IHero
{
    float Health { get; set; }
    float currentHealth { get; set; }
    int Damage { get; set; }
    int Defense { get; set; }
    float Speed { get; set; }
    float DSpeed { get; set; }
    float Range { get; set; }
    void Attack(Collider2D[] hitEnemies);

    void takeDamage(float amount);
}
