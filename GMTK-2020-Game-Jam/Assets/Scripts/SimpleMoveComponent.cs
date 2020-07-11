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
        SetRotation();
        _rb.velocity = (targetPos - transform.position).normalized * speed; 
    }

    private void SetRotation()
    {
        Vector3 vectorToTarget = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 10);
    }
}
