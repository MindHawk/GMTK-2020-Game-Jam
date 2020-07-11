using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSpawner : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }

    public Direction spawnerDirection = Direction.Up;

    // Start is called before the first frame update
    void Start()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;
        SpawnEnemies spawnScript = GetComponent<SpawnEnemies>();
        float spawnerY = cameraHeight * 1.1f; // We offset by an additional 10% so that the enemies spawn out of bounds
        float spawnerX = cameraWidth * 1.1f;
        switch (spawnerDirection)
        {
            case Direction.Up:
                spawnScript.transform.position = new Vector2(0, spawnerY);
                spawnScript.xVariance = cameraWidth;
                break;
            case Direction.Down:
                spawnScript.transform.position = new Vector2(0, -spawnerY);
                spawnScript.xVariance = cameraWidth;
                break;
            case Direction.Left:
                spawnScript.transform.position = new Vector2(-spawnerX, 0);
                spawnScript.yVariance = cameraHeight;
                break;
            case Direction.Right:
                spawnScript.transform.position = new Vector2(spawnerX, 0);
                spawnScript.yVariance = cameraHeight;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
