using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCircleBehaviour : MonoBehaviour
{
    private List<Vector2> waypoints;
    public float timePerWaypoint = 6;
    private float timeLeftToReach = 0;
    private Rigidbody2D _rb;
    private int currentWaypoint;
    private bool firstTime = true;
    
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * screenAspect;
        
        float playAreaY = cameraHeight * 0.7f; // We offset by an additional 20% so the boss is in bounds
        float playAreaX = cameraWidth * 0.8f;
        waypoints = new List<Vector2>
        {
            new Vector2(-playAreaX, -playAreaY),
            new Vector2(playAreaX, -playAreaY),
            new Vector2(playAreaX, playAreaY),
            new Vector2(-playAreaX, playAreaY),
        };
    }

    private void Start()
    {
        currentWaypoint = 0;
        UpdateWaypointDestination();
    }

    private void Update()
    {
        timeLeftToReach -= Time.deltaTime;
        if (timeLeftToReach <= 0)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
            }
            UpdateWaypointDestination();
            timeLeftToReach += timePerWaypoint;
        }
    }

    private void UpdateWaypointDestination()
    {
        Vector3 targetPos = waypoints[currentWaypoint];
        SetRotation();
        if (firstTime)
        {
            _rb.velocity = (targetPos - transform.position) / 3;
            timeLeftToReach = 3;
            firstTime = false;
        }
        else
        {
            _rb.velocity = (targetPos - transform.position) / timePerWaypoint; 
        }
    }

    private void SetRotation()
    {
        Vector2 direction = (waypoints[currentWaypoint] - (Vector2) transform.position).normalized;
        transform.up = direction;
    }
}
