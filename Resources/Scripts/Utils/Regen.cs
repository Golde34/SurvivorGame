using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour
{
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 10;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange())
        {
            /*
             * Player collect the regen, then destroy the diamond
             */
            GameObject.Find("King").GetComponent<IHero>().RegenHealth(15);

            Destroy(gameObject);
        }
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public bool IsPlayerInRange()
    {
        if (GameObject.FindGameObjectWithTag("Hero") != null && GameObject.Find("King") != null)
        {
            var target = GameObject.FindGameObjectWithTag("Hero");
            var realTarget = GameObject.Find("King");

            if (Vector2.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                return true;
            }
        }
        return false;
    }
}
