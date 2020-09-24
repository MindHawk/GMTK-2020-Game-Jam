using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D ParentBody;
    [SerializeField]
    private float HomingSpeed;

    private GameObject homingTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            homingTarget = collision.gameObject;
        }
    }

    private void Update()
    {
        if(homingTarget != null)
        {
            Vector3 newPosition = Vector3.MoveTowards(ParentBody.position, homingTarget.transform.position, HomingSpeed * Time.deltaTime);
            ParentBody.position = newPosition;

            Vector3 moveDirection = gameObject.transform.position - (Vector3)ParentBody.position;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                ParentBody.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            }
        }


    }
}
