﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class StrafingMoveComponent : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    [SerializeField] private float strafingForce = 1;
    [SerializeField] private float strafingSwitchDelay = 3;
    private float _timeLeftToStrafe;
    private bool _isStrafingLeft = true;
    private bool _firstStrafe = true;
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
        _timeLeftToStrafe = strafingSwitchDelay;
    }

    private void Update()
    {
        _timeLeftToStrafe -= Time.deltaTime;
        if (_timeLeftToStrafe <= 0)
        {
            if (_firstStrafe)
            {
                // We have to do this in update or relative force will use our absolute position, despite us being rotated!
                _firstStrafe = false;
                _rb.AddRelativeForce(Vector2.left * (strafingForce / 2), ForceMode2D.Impulse);
                _isStrafingLeft = true;
                _timeLeftToStrafe += (strafingSwitchDelay / 2);
                return;
            }
            _timeLeftToStrafe += strafingSwitchDelay;
            if (_isStrafingLeft)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }

            _isStrafingLeft = !_isStrafingLeft;
        }
    }

    private void MoveLeft()
    {
        _rb.AddRelativeForce(Vector2.left * (strafingForce), ForceMode2D.Impulse);
    }

    private void MoveRight()
    {
        _rb.AddRelativeForce(Vector2.right * (strafingForce), ForceMode2D.Impulse);
    }

    private void SetRotation()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.up = direction;
    }
}
