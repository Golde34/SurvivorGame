using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCreep : Creep
{
    public void SetStat(int level)
    {
        this.speed = 4f * level;
    }

    void Awake()
    {
        // Initiates the variant's parameters
        health = 25;
    }
}
