using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameplayManager : MonoBehaviour
{
    public HeroSpawner spawner;
    public Vector2 speed1 = new Vector2(0, 2f);
    public Vector2 speed2 = new Vector2(2f, 0);
    Vector2 localScale;
    public LayerMask enemyLayers;
    IHero hero;
    [SerializeField] HealBar _healBar;

    // Start is called before the first frame update
    void Start()
    {

        spawner = gameObject.AddComponent<HeroSpawner>();
        spawner.SetFactory(new KingFactory());
        hero = spawner.SpawnHero();
        _healBar.hero = hero;
        IWeapon weapon = hero.UseWeapon();
        hero = new HeroWeaponDecorator(hero, weapon);
        Debug.Log("hero Damage: " + hero.Damage);
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

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, hero.Range, LayerMask.GetMask("Enemy"));
        if (hitEnemies != null && hitEnemies.Length > 0)
        {
            hero.Attack(hitEnemies);
        }
    }

    void GoDown(GameObject gameObject)
    {
        gameObject.transform.Translate(-speed1 * Time.deltaTime);
    }

    void GoUp(GameObject gameObject)
    {
        gameObject.transform.Translate(speed1 * Time.deltaTime);
    }

    void GoRight(GameObject gameObject)
    {
        gameObject.transform.Translate(speed2 * Time.deltaTime);

        localScale = gameObject.transform.localScale;
        if (localScale.x < 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }
    void GoLeft(GameObject gameObject)
    {
        gameObject.transform.Translate(-speed2 * Time.deltaTime);
        localScale = gameObject.transform.localScale;
        if (localScale.x > 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }
}
