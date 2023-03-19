using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class King : MonoBehaviour, IHero
{
    public float Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public float Speed { get; set; }
    public float DSpeed { get; set; }
    public float Range { get; set; }
    public float currentHealth { get; set; }

    public IWeapon Weapon { get; set; }

    private float nextTimeToDealDamage = 0;
    public float timeBetweenEnemyAttack = 3;
    public Vector2 speed1 = new Vector2(0, 2f);
    public Vector2 speed2 = new Vector2(2f, 0);
    Vector2 localScale;
    GameObject target;
    int diamonds = 0;

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Hero");
        gameObject.transform.position = target.transform.position;
    }

    public void Attack(Collider2D[] hitEnemies)
    {
        if (Time.time >= nextTimeToDealDamage)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag.Equals("Enemy"))
                {
                    enemy.GetComponent<Enemy>().TakeDamage(Damage);
                }
            }
            nextTimeToDealDamage = Time.time + DSpeed;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Current Heath: " + currentHealth+"/" + Health + "; Loss: " + amount);

        if (currentHealth <= 0)
        {
            //FIX BUG
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
    }

    public void RegenHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > Health)
        {
            currentHealth = Health;
        }
        Debug.Log("Heath after regen: " + currentHealth);
    }

    public void CollectDiamond(int value)
    {
        diamonds += value;
        Debug.Log("Gain Diamond: " + diamonds);
        SaveTreasure(diamonds);
    }

    public int UseDiamonds()
    {
        return diamonds;
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GoUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GoDown();
        }
    }

    void GoDown()
    {
        target.transform.Translate(-speed1 * Time.deltaTime);
    }

    void GoUp()
    {
        target.transform.Translate(speed1 * Time.deltaTime);
    }

    void GoRight()
    {
        target.transform.Translate(speed2 * Time.deltaTime);

        localScale = gameObject.transform.localScale;
        if (localScale.x < 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }
    void GoLeft()
    {
        target.transform.Translate(-speed2 * Time.deltaTime);
        localScale = gameObject.transform.localScale;
        if (localScale.x > 0)
        {
            localScale.x *= -1;
            gameObject.transform.localScale = localScale;
        }
    }

    public int SaveTreasure(int scoreCount)
    {
        // Load total treasure
        var jsonTextFile = Resources.Load<TextAsset>("Text/playerTreasure");
        Treasure treasure = JsonUtility.FromJson<Treasure>(jsonTextFile.text);
        // Calculate total treasure
        int currentTreasure = treasure.totalTreasure;
        int total = currentTreasure + scoreCount;
        treasure.TotalTreasure = total;
        // Save treasure
        var savedJson = JsonUtility.ToJson(treasure);
        WriteToFile("Resources/Text/playerTreasure.json", savedJson);
        return total;
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.dataPath + "/" + fileName;
    }
}
