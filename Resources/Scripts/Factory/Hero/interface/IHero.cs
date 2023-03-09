using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IHero
{
    int Health { get; set; }
    int Damage { get; set; }
    int Defense { get; set; }
    float Speed { get; set; }
    float DSpeed { get; set; }
    int Range { get; set; }
    void Attack();
}
