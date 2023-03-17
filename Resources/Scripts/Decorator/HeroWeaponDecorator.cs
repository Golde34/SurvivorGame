using UnityEngine;

public class HeroWeaponDecorator : HeroDecorator
{
    public IWeapon weapon;
    public HeroWeaponDecorator(IHero hero, IWeapon weapon) : base(hero)
    {
        this.weapon = weapon;
        hero.Weapon = weapon;
    }

    public override int Damage
    {
        get
        {
            return base.Damage + weapon.Damage;
        }
        set { base.Damage = value; }
    }

    public override void Attack(Collider2D[] hitEnemies)
    {
        base.Attack(hitEnemies);
        weapon.Attack();
    }
}