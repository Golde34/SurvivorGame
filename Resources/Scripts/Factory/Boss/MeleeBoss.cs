using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBoss : Boss
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
