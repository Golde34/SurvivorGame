using Assets.Scripts.Object;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.TextCore.Text;
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

    public FixedJoystick _joystick;

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
        //get fitpoint
        int fitPoint = GetFitPoint();
        hero = new FitpointDecorator(hero, fitPoint);
        hero = new HeroWeaponDecorator(hero, weapon);
        
        Debug.Log("Final Damage of hero in New Game: " + hero.Damage);

        //GUI 
        _healBar.hero = hero;

        _joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Hero");
        hero.Move(_joystick.Horizontal, _joystick.Vertical);

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
        if (selectedoption == 2)
        {
            heroString = "Wizard";
        }

    }
    private void ChooseWeapon(int selecteWeaponsOption)
    {
        if (selecteWeaponsOption == 0)
        {
            weaponString = "Sword";
        }
        if (selecteWeaponsOption == 1)
        {
            weaponString = "Wand";
        }
        if (selecteWeaponsOption == 2)
        {
            weaponString = "Spear";
        }
    }

    private int GetFitPoint()
    {
        int intFitPoint = 0;
        var jsonTextFile = Resources.Load<UnityEngine.TextAsset>("Text/fitPoint");
        FitPoint[] fitPoints = JsonHelper.FromJson<FitPoint>(jsonTextFile.text);
        foreach (var fitPoint in fitPoints)
        {
            if (fitPoint.Name.Equals(heroString))
            {
                switch (weaponString)
                {
                    case "Sword":
                        intFitPoint =  fitPoint.Sword;
                        break;
                    case "Spear":
                        intFitPoint =  fitPoint.Spear;
                        break;
                    case "Wand":
                        intFitPoint =  fitPoint.Wand;
                        break;
                    case "Bow":
                        intFitPoint =  fitPoint.Bow;
                        break;
                    default:
                        intFitPoint =  fitPoint.Sword;
                        break;
                }
            }
        }
        return intFitPoint;
    }   
}