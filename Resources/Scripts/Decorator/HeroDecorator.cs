using UnityEngine;

public abstract class HeroDecorator : IHero
{
    private IHero hero;

    public HeroDecorator(IHero hero)
    {
        this.hero = hero;
    }

    public virtual void Attack(Collider2D[] hitEnemies)
    {
        hero.Attack(hitEnemies);
    }

    public virtual void TakeDamage(float amount)
    {
        hero.TakeDamage(amount);
    }

    public virtual IWeapon UseWeapon(string weaponString)
    {
        IWeapon weapon = hero.UseWeapon(weaponString);
        return weapon;
    }

    public virtual void RegenHealth(float health)
    {
        hero.RegenHealth(health);
    }

    public virtual void CollectDiamond(int value)
    {
        hero.CollectDiamond(value);
    }

    public virtual void Move() { hero.Move(); }

    public virtual float Health { get => hero.Health; set => hero.Health = value; }
    public virtual int Damage
    {
        get { return hero.Damage; }
        set { hero.Damage = value; }
    }
    public virtual float currentHealth { get => hero.currentHealth; set => hero.currentHealth = value; }
    public virtual int Defense { get => hero.Defense; set => hero.Defense = value; }
    public virtual float Speed { get => hero.Speed; set => hero.Speed = value; }
    public virtual float DSpeed { get => hero.DSpeed; set => hero.DSpeed = value; }
    public virtual float Range { get => hero.Range; set => hero.Range = value; }
    public virtual IWeapon Weapon { get => hero.Weapon; set => hero.Weapon = value; }
}
