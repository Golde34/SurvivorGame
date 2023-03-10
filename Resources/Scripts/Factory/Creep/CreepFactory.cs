using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFactory : EnemyFactory
{
    public override void CreateMeleeEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        var meleeCreepGameObject = Resources.Load("Prefabs/MeleeCreep") as GameObject;
        if (meleeCreepGameObject != null)
        {
            var meleeCreep = Instantiate(
                meleeCreepGameObject.transform,
                new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z
                ),
                Quaternion.identity
            );
            meleeCreep.GetComponent<MeleeCreep>().SetStat(level);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateRangedEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        var rangedCreepGameObject = Resources.Load("Prefabs/RangedCreep") as GameObject;
        if (rangedCreepGameObject != null)
        {
            var rangedCreep = Instantiate(
                rangedCreepGameObject.transform,
                new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z
                ),
                Quaternion.identity
            );
            rangedCreep.GetComponent<RangedCreep>().SetStat(level);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}
