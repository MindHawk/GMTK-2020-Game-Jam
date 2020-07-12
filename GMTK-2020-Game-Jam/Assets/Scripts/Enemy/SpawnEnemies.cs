using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public List<SpawnChance> objectsToSpawn;

    public float spawnDelay = 7;
    public float spawnVariance = 3; // Spawn time can vary by up to this much
    [HideInInspector] public float xVariance;
    [HideInInspector] public float yVariance;

    private float _timeToNextSpawn;
    // Start is called before the first frame update
    private void Start()
    {
        _timeToNextSpawn = spawnDelay;
        _timeToNextSpawn += Random.Range(-spawnVariance, spawnVariance);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timeToNextSpawn <= 0)
        {
            SpawnEnemy();
            _timeToNextSpawn += spawnDelay;
            _timeToNextSpawn += Random.Range(-spawnVariance, spawnVariance);
        }

        _timeToNextSpawn -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        int totalWeight = 0;
        foreach (SpawnChance spawnChance in objectsToSpawn)
        {
            totalWeight += spawnChance.spawnWeight;
        }
        int randomWeight = Random.Range(1, totalWeight + 1);
        GameObject objectToSpawn = null;
        foreach (SpawnChance spawnChance in objectsToSpawn)
        {
            if (randomWeight <= spawnChance.spawnWeight)
            {
                objectToSpawn = spawnChance.objectToSpawn;
                break;
            }
            randomWeight -= spawnChance.spawnWeight;
        }
        Vector3 transPos = transform.position;
        Vector2 spawnLocation = new Vector2(transPos.x + Random.Range(-xVariance, xVariance), transPos.y + Random.Range(-yVariance, yVariance));
        
        Instantiate(objectToSpawn, spawnLocation, Quaternion.identity);
    }
}
