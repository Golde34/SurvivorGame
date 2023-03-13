using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] 
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Hero") != null)
        {
            target = GameObject.FindGameObjectWithTag("Hero").transform;
            transform.position = new Vector3(target.position.x, target.position.y, -10);
        }
    }
}
