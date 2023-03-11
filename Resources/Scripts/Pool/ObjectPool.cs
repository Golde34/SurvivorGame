using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledMeleeCreep;
    public List<GameObject> pooledRangedCreep;    
    public List<GameObject> pooledMeleeBoss;
    public List<GameObject> pooledRangedBoss;
    public int amountMeleeCreepToPool;
    public int amountRangedCreepToPool;    
    public int amountMeleeBossToPool;
    public int amountRangedBossToPool;

    private void Awake()
    {
        SharedInstance = this;

        amountMeleeCreepToPool = 60;
        amountRangedCreepToPool = 40;
        amountMeleeBossToPool = 5;
        amountRangedBossToPool = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledMeleeCreep = new List<GameObject>();
        pooledRangedCreep = new List<GameObject>();
        pooledMeleeBoss = new List<GameObject>();
        pooledRangedBoss = new List<GameObject>();

        var meleeBossGameObject = Resources.Load("Prefabs/MeleeBoss") as GameObject;
        if (meleeBossGameObject != null)
        {
            for (int i = 0; i < amountMeleeBossToPool; i++) { 
                var meleeBoss = Instantiate(meleeBossGameObject);
                meleeBoss.SetActive(false);
                pooledMeleeBoss.Add(meleeBoss);
            }
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }

        var rangedBossGameObject = Resources.Load("Prefabs/RangedBoss") as GameObject;
        if (rangedBossGameObject != null)
        {
            for (int i = 0; i < amountRangedBossToPool; i++)
            {
                var rangedBoss = Instantiate(rangedBossGameObject);
                rangedBoss.SetActive(false);
                pooledRangedBoss.Add(rangedBoss);
            }
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }

        var meleeCreepGameObject = Resources.Load("Prefabs/MeleeCreep") as GameObject;
        if (meleeCreepGameObject != null)
        {
            for (int i = 0; i < amountMeleeCreepToPool; i++)
            {
                var meleeCreep = Instantiate(meleeCreepGameObject);
                meleeCreep.SetActive(false);
                pooledMeleeCreep.Add(meleeCreep);
            }
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }

        var rangedCreepGameObject = Resources.Load("Prefabs/RangedCreep") as GameObject;
        if (rangedCreepGameObject != null)
        {
            for (int i = 0; i < amountRangedCreepToPool; i++)
            {
                var rangedCreep = Instantiate(rangedCreepGameObject);
                rangedCreep.SetActive(false);
                pooledRangedCreep.Add(rangedCreep);
            }
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetPooledObject(string Type)
    {
        if (Type.Equals("meleeBoss"))
        {
            for (int i = 0; i < amountMeleeBossToPool; i++)
            {
                if (!pooledMeleeBoss[i].activeInHierarchy)
                {
                    return pooledMeleeBoss[i];
                }
            }
            return null;
        }
        if (Type.Equals("rangedBoss"))
        {
            for (int i = 0; i < amountRangedBossToPool; i++)
            {
                if (!pooledRangedBoss[i].activeInHierarchy)
                {
                    return pooledRangedBoss[i];
                }
            }
            return null;
        }
        if (Type.Equals("meleeCreep"))
        {
            for (int i = 0; i < amountMeleeCreepToPool; i++)
            {
                if (!pooledMeleeCreep[i].activeInHierarchy)
                {
                    return pooledMeleeCreep[i];
                }
            }
            return null;
        }
        if (Type.Equals("rangedCreep"))
        {
            for (int i = 0; i < amountRangedCreepToPool; i++)
            {
                if (!pooledRangedCreep[i].activeInHierarchy)
                {
                    return pooledRangedCreep[i];
                }
            }
            return null;
        }
        return null;
    }
}
