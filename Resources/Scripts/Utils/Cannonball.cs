using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            timer.Duration = 3;
            timer.Run();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            gameObject.SetActive(false);
        }
    }
}