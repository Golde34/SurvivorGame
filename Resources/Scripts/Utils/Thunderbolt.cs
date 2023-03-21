using UnityEngine;

public class Thunderbolt : MonoBehaviour
{
    public GameObject Target { get; set; }
    public float Damage { get; set; }
    private Timer timer;

    public void ResetTimer()
    {
        if (timer != null && timer.Finished)
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
        if (Target.transform.position != null)
        {
            transform.Translate((Target.transform.position - transform.position) * Time.deltaTime * 2);
            if (transform.position.x - Target.transform.position.x < 0.2f &&
                transform.position.y - Target.transform.position.y < 0.2f) 
            {
                Target.GetComponent<Enemy>().TakeDamage(Damage);
                gameObject.SetActive(false);
            }
        }
    }

}