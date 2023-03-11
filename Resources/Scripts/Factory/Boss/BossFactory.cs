using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : EnemyFactory
{
    public override void CreateMeleeEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        GameObject meleeBoss = ObjectPool.SharedInstance.GetPooledObject("meleeBoss");
        if (meleeBoss != null)
        {
            meleeBoss.transform.position = spawnPosition;
            meleeBoss.GetComponent<MeleeBoss>().SetStat(level);
            meleeBoss.SetActive(true);
        }
    }

    public override void CreateRangedEnemy(Transform spawnPoint, int level)
    {
        var spawnPosition = spawnPoint.transform.position;
        GameObject rangedBoss = ObjectPool.SharedInstance.GetPooledObject("rangedBoss");
        if (rangedBoss != null)
        {
            rangedBoss.transform.position = spawnPosition;
            rangedBoss.GetComponent<RangedBoss>().SetStat(level);
            rangedBoss.SetActive(true);
        }
    }
}
