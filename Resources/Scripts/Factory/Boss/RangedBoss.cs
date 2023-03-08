using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBoss : Boss
{
    void Awake()
    {
        // Initiates the variant's parameters
        speed = 8f;
        health = 50;
    }
}
