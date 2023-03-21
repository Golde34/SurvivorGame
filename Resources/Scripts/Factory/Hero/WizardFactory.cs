﻿using System.Threading;
using UnityEngine;

public class WizardFactory : MonoBehaviour, IHeroFactory
{
    public IHero CreateHero()
    {
        var WizardGameObj = Resources.Load("Prefabs/HeroWizard") as GameObject;
        var WizardObj = Instantiate(WizardGameObj);
        Wizard Wizard = WizardObj.GetComponent<Wizard>();
        Wizard.Health = 180;
        Wizard.currentHealth = Wizard.Health;
        Wizard.Damage = 20;
        Wizard.Defense = 15;
        Wizard.Speed = 1;
        Wizard.DSpeed = 2;
        Wizard.Range = 0.5f;

        return Wizard;
    }
}
