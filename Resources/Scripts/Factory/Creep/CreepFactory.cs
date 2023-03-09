using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFactory : EnemyFactory
{
    public override void CreateMeleeEnemy(Transform spawnPoint)
    {
        var spawnPosition = spawnPoint.transform.position;
        var meleeCreepGameObject = Resources.Load("Prefabs/MeleeCreep") as GameObject;
        if (meleeCreepGameObject != null)
        {
            var meleeBoss = Instantiate(
                meleeCreepGameObject.transform,
                new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateRangedEnemy(Transform spawnPoint)
    {
        var spawnPosition = spawnPoint.transform.position;
        var rangedCreepGameObject = Resources.Load("Prefabs/RangedCreep") as GameObject;
        if (rangedCreepGameObject != null)
        {
            var rangedBoss = Instantiate(
                rangedCreepGameObject.transform,
                new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}
