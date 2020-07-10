using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveComponent : MonoBehaviour
{
    public Transform playerTransform;
    public int speed;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector3 targetPos = playerTransform.position;
        _rb.velocity = (targetPos - transform.position).normalized * speed; 
    }
}
