using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;

    public float spawnDelay = 7;
    public float spawnVariance = 3; // Spawn time can vary by up to this much

    private float _timeToNextSpawn;
    // Start is called before the first frame update
    private void Start()
    {
        _timeToNextSpawn = spawnDelay;
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
        Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)], transform.position, Quaternion.identity);
    }
}
