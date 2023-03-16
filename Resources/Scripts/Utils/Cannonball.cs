using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class Cannonball : MonoBehaviour
{
    public Vector3 Destination { get; set; }
    public float Damage { get; set; }
    private Timer timer;

    public void ResetTimer()
    {
        if(timer != null && timer.Finished)
        {
            timer.Duration = 5;
            timer.Run();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished || Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Hero").transform.position) <= 0.2f)
        {
            Explode();
        }

        if (Destination != null)
        {
            transform.Translate((Destination - transform.position) * Time.deltaTime * 2);
        }
    }

    private void Explode()
    {
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Hero").transform.position) <= 0.2f)
        {
            if(GameObject.FindGameObjectWithTag("Hero") != null)
            {
                GameObject.FindGameObjectWithTag("Hero").GetComponent<IHero>().TakeDamage(15);
            }
        }
        gameObject.SetActive(false);
    }
}