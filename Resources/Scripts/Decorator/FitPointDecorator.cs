using Assets.Scripts.Object;
using UnityEngine;

public class FitpointDecorator : HeroDecorator
{
    public int fitpoint;
    public FitpointDecorator(IHero hero, int fitpoint) : base(hero)
    {
        this.fitpoint = fitpoint;
    }

    public override int Damage
    {
        get
        {
            return base.Damage + fitpoint;
        }
        set { base.Damage = value; }
    }
}