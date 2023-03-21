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

    IWeapon Weapon { get; set; }

    void Attack(Collider2D[] hitEnemies);
    void Move(float x, float y);
    void TakeDamage(float amount);
    void RegenHealth(float health);
    void CollectDiamond(int value);
    int UseDiamonds();
}
