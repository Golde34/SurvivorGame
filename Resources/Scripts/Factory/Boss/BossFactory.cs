using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : EnemyFactory
{
    public override void CreateMeleeEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        var meleeBossGameObject = Resources.Load("Prefabs/MeleeBoss") as GameObject;
        if (meleeBossGameObject != null)
        {
            var meleeBoss = Instantiate(
                meleeBossGameObject.transform,
                new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z
                ),
                Quaternion.identity
            );
            meleeBoss.GetComponent<MeleeBoss>().SetStat(level);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateRangedEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        var rangedBossGameObject = Resources.Load("Prefabs/RangedBoss") as GameObject;
        if (rangedBossGameObject != null)
        {
            var rangedBoss = Instantiate(
                rangedBossGameObject.transform,
                new Vector3(
                    spawnPosition.x,
                    spawnPosition.y,
                    spawnPosition.z
                ),
                Quaternion.identity
            );
            rangedBoss.GetComponent<RangedBoss>().SetStat(level);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}
