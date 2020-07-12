using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoveBehaviour : MonoBehaviour
{
    public List<Vector2> waypoints;
    public float timePerWaypoint = 6;
    private float timeLeftToReach = 0;
    private Rigidbody2D _rb;
    private int currentWaypoint;
    
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentWaypoint = 0;
        UpdateWaypointDestination();
        timeLeftToReach += timePerWaypoint;
    }

    private void Update()
    {
        timeLeftToReach -= Time.deltaTime;
        if (timeLeftToReach <= 0)
        {
            currentWaypoint++;
            if (currentWaypoint > waypoints.Count)
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
        _rb.velocity = (targetPos - transform.position) / timePerWaypoint; 
    }

    private void SetRotation()
    {
        Vector2 direction = (waypoints[currentWaypoint] - (Vector2) transform.position).normalized;
        transform.up = direction;
    }
}
