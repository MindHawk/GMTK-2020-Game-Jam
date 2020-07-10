using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float spawnDelay = 5;
    public Transform playerTransform;

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
        }

        _timeToNextSpawn -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        SimpleMoveComponent enemy = Instantiate(objectToSpawn, transform.position, Quaternion.identity).GetComponent<SimpleMoveComponent>();
        enemy.playerTransform = playerTransform;
    }
}
