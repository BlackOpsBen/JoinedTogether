using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] CharacterMovement Hacker;
    [SerializeField] CharacterMovement Cleaner;
    [SerializeField] float useThreshold = 1f;
    [SerializeField] float upSpeed = 1f;
    [SerializeField] float downSpeed = 2f;
    [SerializeField] float speedMultiplier = 1f;
    [SerializeField] float maxYPos = -1f;

    bool isLeftHeld = false;
    bool isRightHeld = false;

    private int moveDirection = 0;

    private void Update()
    {
        CheckRopeHandles();
        Move(GetMoveDirection());
    }

    private void CheckRopeHandles()
    {
        isLeftHeld = Hacker.GetDistanceToRope() < useThreshold;
        isRightHeld = Cleaner.GetDistanceToRope() < useThreshold;
    }

    private int GetMoveDirection()
    {
        if (isLeftHeld && isRightHeld)
        {
            return 1;
        }
        else if (!isLeftHeld && !isRightHeld)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    private void Move(int direction)
    {
        float speed;

        if (direction < 0)
        {
            speed = downSpeed;
        }
        else
        {
            speed = upSpeed;
        }

        float newYPos = Mathf.Min(transform.position.y + speed * speedMultiplier * direction * Time.deltaTime, maxYPos);

        transform.position = new Vector2(transform.position.x, newYPos);
    }
}
