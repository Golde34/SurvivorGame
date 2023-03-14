using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiamondSpawner : MonoBehaviour
{
    [System.Serializable]
    public class TransformEvent : UnityEvent<Transform> { }
    public TransformEvent _EnemyDieEvent;
    private GameObject diamondGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (_EnemyDieEvent == null)
            _EnemyDieEvent = new TransformEvent();

        _EnemyDieEvent.AddListener(SpawnDiamond);

        diamondGameObject = Resources.Load("Prefabs/Diamond") as GameObject;
    }

    void SpawnDiamond(Transform transform)
    {
        if (diamondGameObject != null)
        {
            var diamond = Instantiate(
                transform.transform,
                new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z
                ),
                Quaternion.identity
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
