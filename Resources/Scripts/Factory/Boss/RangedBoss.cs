using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBoss : Boss
{
    public void SetStat(int level)
    {
        this.speed = 2f * level;
    }

    void Awake()
    {
        // Initiates the variant's parameters
        health = 50;
    }
}
