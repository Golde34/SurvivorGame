using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    protected float health;
    protected float speed;
    protected float dame;
    protected float heal;
    protected int Diamond;
    protected float range;

    Timer timer;

    public enum EnemyType
    {
        Boss, Creep
    }

    public abstract EnemyType GetEnemyType();

    // Start is called before the first frame update
    private void Start()
    {
        // Initiates timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 20;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Hero") != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Hero").transform.position, speed * 0.2f * Time.deltaTime);
        }

        // Put a life timer on those things to save memmory
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Hero"))
        {
            Debug.Log("huhuhuhuhuhuhuhuhuhuhu");
            Destroy(gameObject);
        }
    }
}
