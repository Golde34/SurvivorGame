using Assets.Scripts.Object;
using UnityEngine;

public class RangedWeaponDecorator : HeroDecorator
{
    public IWeapon weapon;
    public RangedWeaponDecorator(IHero hero, IWeapon weapon) : base(hero)
    {
        this.weapon = weapon;
    }

    public override int Damage
    {
        get
        {
            return 0;
        }
        set { base.Damage = value; }
    }

    public override void Attack(Collider2D[] hitEnemies)
    {
        weapon.Damage = base.Damage + weapon.Damage;
        weapon.Attack();
    }
}