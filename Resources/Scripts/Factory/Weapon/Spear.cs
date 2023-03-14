using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Spear : MonoBehaviour, IWeapon
{
    public string Name => "Spear";
    public int Damage { get; set; }
    public int FitPoint { get; set; }

    public Vector3 WeaponPoint { get; set; }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Weapon");
        gameObject.transform.position = target.transform.position;
    }

    public void Attack()
    {
    }
}
