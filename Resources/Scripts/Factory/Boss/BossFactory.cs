using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : EnemyFactory
{
    public override void CreateMeleeEnemy()
    {
        var portalTransformposition = portalTransform.transform.position;
        var meleeBossGameObject = Resources.Load("Prefabs/MeleeBoss") as GameObject;
        if (meleeBossGameObject != null)
        {
            var meleeBoss = Instantiate(
                meleeBossGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateRangedEnemy()
    {
        var portalTransformposition = portalTransform.transform.position;
        var rangedBossGameObject = Resources.Load("Prefabs/RangedBoss") as GameObject;
        if (rangedBossGameObject != null)
        {
            var rangedBoss = Instantiate(
                rangedBossGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
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
