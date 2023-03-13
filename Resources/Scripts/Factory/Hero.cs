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

    void GoDown(float force)
    {
        gameObject.transform.Translate(-speed1 * Time.deltaTime * 2);
    }

    void GoUp(float force)
    {
        gameObject.transform.Translate(speed1 * Time.deltaTime * 2);
    }

    void GoRight(float force)
    {
        gameObject.transform.Translate(speed2 * Time.deltaTime * 2);

        localScale = transform.localScale;
        if (localScale.x < 0)
        {
            localScale.x *= -1;
            this.gameObject.transform.localScale = localScale;
        }
    }

    void GoLeft(float force)
    {
        gameObject.transform.Translate(-speed2 * Time.deltaTime * 2);
        if (localScale.x > 0)
        {
            localScale.x *= -1;
            this.gameObject.transform.localScale = localScale;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft(0.5f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight(0.5f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GoUp(0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GoDown(0.5f);
        }
    }

}
