using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCreep : Creep
{
    void Awake()
    {
        // Initiates the variant's parameters
        speed = 8f;
        health = 25;
    }
}
