using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public string Name => "Sword";
    public int Damage { get; set; }
    public int FitPoint { get; set; }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Weapon");
        gameObject.transform.position = target.transform.position;
    }

    public void Attack()
    {
    }
}
