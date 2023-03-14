using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Vector2 speed1 = new Vector2(0, 1f);
    public Vector2 speed2 = new Vector2(1f, 0);
    protected float range = 3;
    protected float dmg = 20;


    private float nextTimeToTakeDamage;
    public float timeBetweenEnemyAttack;

    Vector2 localScale;
    public LayerMask enemyLayers;

}
