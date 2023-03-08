using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCreep : Creep
{
    void Awake()
    {
        // Initiates the variant's parameters
        speed = 4f;
        health = 25;
    }
}
