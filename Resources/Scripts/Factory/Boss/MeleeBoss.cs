using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBoss : Boss
{
    void Awake()
    {
        // Initiates the variant's parameters
        speed = 2f;
        health = 50;
    }
}
