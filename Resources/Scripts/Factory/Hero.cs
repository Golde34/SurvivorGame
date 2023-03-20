using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public float Speed { get; set; }
    public float DSpeed { get; set; }
    public float Range { get; set; }

    private float nextTimeToDealDamage = 0;
    public float timeBetweenEnemyAttack = 3;
    public Vector2 speed1 = new Vector2(0, 2f);
    public Vector2 speed2 = new Vector2(2f, 0);
    Vector2 localScale;
    GameObject target;

    public void Attack(Collider2D[] hitEnemies)
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

    public float TakeDamage(float amount, float currentHealth)
    {
        currentHealth -= amount;
        Debug.Log("Current Heath: " + currentHealth + "/" + Health + "; Loss: " + amount);

        if (currentHealth <= 0)
        {
            //FIX BUG
            Time.timeScale = 0;
            gameObject.SetActive(false);
        }
        return currentHealth;
    }

    public float RegenHealth(float health, float currentHealth)
    {
        currentHealth += health;
        if (currentHealth > Health)
        {
            currentHealth = Health;
        }
        Debug.Log("Heath after regen: " + currentHealth);
        return currentHealth;
    }

    public int CollectDiamond(int value, int diamonds)
    {
        diamonds += value;
        Debug.Log("Gain Diamond: " + diamonds);
        SaveTreasure(diamonds);
        return diamonds;
    }

    public void Move(GameObject target, GameObject localPosition)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GoLeft(target, localPosition);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GoRight(target, localPosition);
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

    void GoDown(GameObject target)
    {
        target.transform.Translate(-speed1 * Time.deltaTime);
    }

    void GoUp(GameObject target)
    {
        target.transform.Translate(speed1 * Time.deltaTime);
    }

    void GoRight(GameObject target, GameObject localPosition)
    {
        target.transform.Translate(speed2 * Time.deltaTime);

        var localScale = localPosition.transform.localScale;
        if (localScale.x < 0)
        {
            localScale.x *= -1;
            localPosition.transform.localScale = localScale;
        }
    }
    void GoLeft(GameObject target, GameObject localPosition)
    {
        target.transform.Translate(-speed2 * Time.deltaTime);
        var localScale = localPosition.transform.localScale;
        if (localScale.x > 0)
        {
            localScale.x *= -1;
            localPosition.transform.localScale = localScale;
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
