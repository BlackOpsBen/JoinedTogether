using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speedToTask = 2f;
    [SerializeField] float speedToRope = 1f;
    [SerializeField] float speedMultiplier = 1f;
    private float currentSpeed;

    [SerializeField] Transform ropeDestination;
    [SerializeField] Transform taskDestination;
    private Transform currentDestination;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentSpeed = speedToTask;
        currentDestination = taskDestination;
    }

    private void Update()
    {
        UpdateSpeed();
        Move();
    }

    private void UpdateSpeed()
    {
        if (currentDestination == taskDestination)
        {
            currentSpeed = speedToTask;
        }
        else
        {
            currentSpeed = speedToRope;
        }
    }

    private void Move()
    {
        //float distToDest = Vector2.Distance(transform.position, currentDestination.position);
        transform.position = Vector2.MoveTowards(transform.position, currentDestination.position, currentSpeed * speedMultiplier * Time.deltaTime);
    }

    public void GrabRope(bool value)
    {
        if (value)
        {
            currentDestination = ropeDestination;
        }
        else
        {
            currentDestination = taskDestination;
        }

        sr.flipX = value;
    }

    public float GetDistanceToRope()
    {
        return Vector2.Distance(transform.position, ropeDestination.position);
    }

    public float GetDistanceToTask()
    {
        return Vector2.Distance(transform.position, taskDestination.position);
    }
}
