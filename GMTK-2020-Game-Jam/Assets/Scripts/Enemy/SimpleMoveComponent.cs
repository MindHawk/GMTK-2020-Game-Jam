using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveComponent : MonoBehaviour
{
    public Vector2 playerTransformPosition = new Vector2(0, 0);
    public float timeToReachPlayer = 6;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector3 targetPos = playerTransformPosition;
        SetRotation();
        _rb.velocity = (targetPos - transform.position) / timeToReachPlayer; 
    }

    private void SetRotation()
    {
        Vector2 direction = (playerTransformPosition - (Vector2) transform.position).normalized;
        transform.up = direction;
    }
}
