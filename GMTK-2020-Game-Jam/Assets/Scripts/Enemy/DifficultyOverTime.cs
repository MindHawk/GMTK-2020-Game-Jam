using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class SpawnerSettings
{
    public List<SpawnChance> objectsToSpawn;
    public float spawnDelay = 7;
    public float spawnVariance = 3;
    public float difficultyDuration;
    public GameObject levelBoss;
}

public class DifficultyOverTime : MonoBehaviour
{
    public List<SpawnerSettings> difficultyLevels;

    private float _difficultyActiveDuration;
    private int _activeDifficulty = 0;
    [SerializeField]
    private List<SpawnEnemies> spawners;

    private bool finalDifficulty = false;
    
    [SerializeField]
    private TextMeshProUGUI LevelText;

    private void Start()
    {
        _activeDifficulty = -1;
    }
    
    private void Update()
    {
        if (finalDifficulty) return;
        _difficultyActiveDuration -= Time.deltaTime;
        if (_difficultyActiveDuration <= 0)
        {
            _activeDifficulty++;
            _difficultyActiveDuration += difficultyLevels[_activeDifficulty].difficultyDuration;
            ChangeSpawnerDifficulty(_activeDifficulty);
            if (difficultyLevels.Count - 1 == _activeDifficulty)
            {
                finalDifficulty = true;
            }
            LevelText.text = "Level: " + (_activeDifficulty + 1);
        }
    }

    private void ChangeSpawnerDifficulty(int difficulty)
    {
        // For simplicity bosses always spawn in the bottom left of the screen
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;
        
        float playAreaY = cameraHeight * 1.1f; // We offset by an additional 10% so the boss spawns out of bounds
        float playAreaX = cameraWidth * 1.1f;
        if (difficultyLevels[difficulty].levelBoss != null)
        {
            Instantiate(difficultyLevels[difficulty].levelBoss, new Vector2(-playAreaX, -playAreaY), quaternion.identity);
        }
        foreach (SpawnEnemies spawner in spawners)
        {
            spawner.spawnDelay = difficultyLevels[difficulty].spawnDelay;
            spawner.spawnVariance = difficultyLevels[difficulty].spawnVariance;
            spawner.objectsToSpawn = difficultyLevels[difficulty].objectsToSpawn;
        }
    }
}
