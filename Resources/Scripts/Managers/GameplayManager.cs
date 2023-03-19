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

    public ChracterDatabase characterDB;
    public WeaponsDatabase weaponDB;
    private int selectedoption = 0;
    private int selecteWeaponsOption = 0;

    private string heroString;
    private string weaponString;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedoption = 0;
        }
        else
        {
            Load();
        }

        ChooseCharacter(selectedoption);

        if (!PlayerPrefs.HasKey("selectedWeaponsOption"))
        {
            selecteWeaponsOption = 0;
        }
        else
        {
            LoadWeapon();
        }
        ChooseWeapon(selecteWeaponsOption);
        Debug.Log(selecteWeaponsOption);
        //heroString = "King";
        //weaponString = "Sword";

        CharacterStateEvent characterEvent = new CharacterStateEvent();
        spawner = gameObject.AddComponent<HeroSpawner>();
        hero = characterEvent.HeroState(spawner, heroString);

        IWeapon weapon = characterEvent.WeaponState(weaponString);

        //Decorate
        hero = new HeroWeaponDecorator(hero, weapon);

        //GUI 
        _healBar.hero = hero;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Hero");
        hero.Move();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, hero.Range, LayerMask.GetMask("Enemy"));
        if (hitEnemies != null && hitEnemies.Length > 0)
        {
            hero.Attack(hitEnemies);
        }
    }

    private void Load()
    {
        selectedoption = PlayerPrefs.GetInt("selectedOption");
    }
    private void LoadWeapon()
    {
        selecteWeaponsOption = PlayerPrefs.GetInt("selectedWeaponsOption");
    }
    private void ChooseCharacter(int selectedoption)
    {
        if (selectedoption == 0)
        {
            heroString = "King";
        }
        if (selectedoption == 1)
        {
            heroString = "Knight";
        }
    
    }
    private void ChooseWeapon(int selecteWeaponsOption)
    {
        if (selecteWeaponsOption == 0)
        {
            weaponString = "Sword";
        }
        if (selecteWeaponsOption == 2)
        {
            weaponString = "Spear";
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
        Debug.Log("localscale right:" + localScale);
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
        Debug.Log("localscale left:" + localScale);

        if (localScale.x > 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }
}
