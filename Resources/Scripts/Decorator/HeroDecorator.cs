using UnityEngine;

public abstract class HeroDecorator : IHero
{
    private IHero hero;

    public HeroDecorator(IHero hero)
    {
        this.hero = hero;
    }

    public void Attack(Collider2D[] hitEnemies)
    {
        hero.Attack(hitEnemies);
    }

    public void TakeDamage(float amount)
    {
        hero.TakeDamage(amount);
    }

    public void UseWeapon()
    {
        hero.UseWeapon();
    }

    public void RegenHealth(float health)
    {
        hero.RegenHealth(health);
    }

    public void CollectDiamond(int value)
    {
        hero.CollectDiamond(value);
    }

    public float Health { get => hero.Health; set => hero.Health = value; }
    public int Damage { get => hero.Damage; set => hero.Damage = value; }
    public float currentHealth { get => hero.currentHealth; set => hero.currentHealth = value; }
    public int Defense { get => hero.Defense; set => hero.Defense = value; }
    public float Speed { get => hero.Speed; set => hero.Speed = value; }
    public float DSpeed { get => hero.DSpeed; set => hero.DSpeed = value; }
    public float Range { get => hero.Range; set => hero.Range = value; }
    public IWeapon Weapon { get => hero.Weapon; set => hero.Weapon = value; }
}
