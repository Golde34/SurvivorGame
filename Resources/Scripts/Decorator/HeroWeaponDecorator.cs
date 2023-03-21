using UnityEngine;

public class HeroWeaponDecorator : HeroDecorator
{
    public IWeapon weapon;
    public int weaponDamage;
    public HeroWeaponDecorator(IHero hero, IWeapon weapon, int weaponDamage) : base(hero)
    {
        this.weapon = weapon;
        hero.Weapon = weapon;
        this.weaponDamage = weaponDamage;
    }

    public override int Damage
    {
        get
        {
            return base.Damage + weaponDamage;
        }
        set { base.Damage = value; }
    }

    public override void Attack(Collider2D[] hitEnemies)
    {
        base.Attack(hitEnemies);
        weapon.Attack();
    }
}