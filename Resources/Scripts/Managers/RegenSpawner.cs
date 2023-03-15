using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenSpawner : MonoBehaviour
{
    public TransformEvent _EnemyDieEvent;
    private GameObject regenGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (_EnemyDieEvent == null)
            _EnemyDieEvent = new TransformEvent();

        _EnemyDieEvent.AddListener(SpawnDiamond);

        regenGameObject = Resources.Load("Prefabs/Regen") as GameObject;
    }

    void SpawnDiamond(Transform transform)
    {
        if (regenGameObject != null)
        {
            var diamond = Instantiate(
                regenGameObject.transform,
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
