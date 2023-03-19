using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Diamond : MonoBehaviour
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
             * Player collect the diamond, then destroy the diamond
             */
            GameObject.FindGameObjectWithTag("Hero").GetComponent<IHero>().CollectDiamond(1);
            Destroy(gameObject);
        }
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public bool IsPlayerInRange()
    {
        if (GameObject.FindGameObjectWithTag("Hero") != null)
        {
            var target = GameObject.FindGameObjectWithTag("Hero");

            if (Vector2.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                return true;
            }
        }
        return false;
    }
}
