using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWING, WAITING, COUNTING, ENDROUND };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public int count;
        public float rate;
    }

    private int nextWave = 1;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public BossFactory bossFactory;
    public CreepFactory creepFactory;

    public Transform[] spawnPoints;


    private float searchCountDown = 1f;
    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("no spawn point");
        }

        waveCountDown = timeBetweenWaves;

        bossFactory = gameObject.AddComponent<BossFactory>();
        creepFactory = gameObject.AddComponent<CreepFactory>();
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if enemy are still alive
            if (!EnemyIsAlive())
            {

                //begin new round 

                WaveComplete();
            }
            else
            {
                return;
            }
        }

        if (state != SpawnState.ENDROUND)
        {
            if (waveCountDown <= 0)
            {
                if (state != SpawnState.SPAWING)
                {
                    var wave = new Wave();
                    wave.name = "Wave "+nextWave;
                    wave.count = (int)Math.Ceiling(15 * Math.Pow(nextWave, 0.25f));
                    wave.rate = 2;

                    Debug.Log(wave.name+" "+wave.count);

                    //Start spawning waves
                    StartCoroutine(SpawnWave(wave));
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }

    }

    void WaveComplete()
    {
        Debug.Log("Wave " + nextWave + " complete");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;
        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave:" + _wave.name);
        state = SpawnState.SPAWING;


        //Spawn

        for (int i = 0; i < (int)Math.Ceiling((_wave.count-2)*0.4f); i++)
        {
            creepFactory.CreateRangedEnemy(spawnPoints[Random.Range(0, spawnPoints.Length)], nextWave);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        for (int i = 0; i < (int)Math.Ceiling((_wave.count - 2) * 0.6f); i++)
        {
            creepFactory.CreateMeleeEnemy(spawnPoints[Random.Range(0, spawnPoints.Length)], nextWave);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        yield return new WaitForSeconds(2f / _wave.rate);
        bossFactory.CreateRangedEnemy(spawnPoints[Random.Range(0, spawnPoints.Length)], nextWave);

        yield return new WaitForSeconds(3f / _wave.rate);
        bossFactory.CreateMeleeEnemy(spawnPoints[Random.Range(0, spawnPoints.Length)], nextWave);

        state = SpawnState.WAITING;

        yield break;
    }

}