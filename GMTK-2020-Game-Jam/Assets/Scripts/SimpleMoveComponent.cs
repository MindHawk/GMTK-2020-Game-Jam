using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveComponent : MonoBehaviour
{
    public Transform playerTransform;
    public int speed;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(_rb.position, playerTransform.position, speed * Time.deltaTime);
        _rb.MovePosition(newPosition);
    }
}
