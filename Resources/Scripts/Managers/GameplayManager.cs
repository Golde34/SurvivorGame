using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameplayManager : MonoBehaviour
{
    public HeroSpawner spawner;
    public Vector2 speed1 = new Vector2(0, 1f);
    public Vector2 speed2 = new Vector2(1f, 0);
    protected float range = 10;
    Vector2 localScale;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        spawner.SetFactory(new KingFactory());
        spawner.SpawnHero();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Hero");
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft(target);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight(target);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GoUp(target);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GoDown(target);
        }
    }
    void GoDown(GameObject gameObject)
    {
        gameObject.transform.Translate(-speed1 * Time.deltaTime * 2);
    }

    void GoUp(GameObject gameObject)
    {
        gameObject.transform.Translate(speed1 * Time.deltaTime * 2);
    }

    void GoRight(GameObject gameObject)
    {
        gameObject.transform.Translate(speed2 * Time.deltaTime * 2);

        localScale = gameObject.transform.localScale;
        if (localScale.x < 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }
    void GoLeft(GameObject gameObject)
    {
        gameObject.transform.Translate(-speed2 * Time.deltaTime * 2);
        localScale = gameObject.transform.localScale;
        if (localScale.x > 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }
}
