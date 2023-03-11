using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFactory : EnemyFactory
{
    public override void CreateMeleeEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        GameObject meleeCreep = ObjectPool.SharedInstance.GetPooledObject("meleeCreep");
        if (meleeCreep != null)
        {
            meleeCreep.transform.position = spawnPosition;
            meleeCreep.GetComponent<MeleeCreep>().SetStat(level);
            meleeCreep.SetActive(true);
        }
    }

    public override void CreateRangedEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        GameObject rangedCreep = ObjectPool.SharedInstance.GetPooledObject("rangedCreep");
        if (rangedCreep != null)
        {
            rangedCreep.transform.position = spawnPosition;
            rangedCreep.GetComponent<RangedCreep>().SetStat(level);
            rangedCreep.SetActive(true);
        }
    }
}
