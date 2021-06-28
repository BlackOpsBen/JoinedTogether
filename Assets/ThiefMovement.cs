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
    [SerializeField] float floorStopDistance = 1f;
    private float minYPos = float.MaxValue;

    private PulleyLightAndSound pulleyLight;

    bool isLeftHeld = false;
    bool isRightHeld = false;

    private LevelBuilder levelBuilder;

    private bool hasSpokenDirection = false;
    private int prevDirection = 0;

    private AnimationSwitcher hackerAnimSwitcher;
    private AnimationSwitcher cleanerAnimSwitcher;

    [SerializeField] RotateWheel rotateWheel;

    private void Awake()
    {
        hackerAnimSwitcher = GameObject.FindGameObjectWithTag("Hacker").GetComponent<AnimationSwitcher>();
        cleanerAnimSwitcher = GameObject.FindGameObjectWithTag("Cleaner").GetComponent<AnimationSwitcher>();

        pulleyLight = FindObjectOfType<PulleyLightAndSound>();
    }

    private void Start()
    {
        levelBuilder = FindObjectOfType<LevelBuilder>();
    }

    private void Update()
    {
        minYPos = levelBuilder.GetFloorYPos();

        if (GameManager.Instance.GetIsPlaying())
        {
            CheckRopeHandles();
            Move(GetMoveDirection());

            hackerAnimSwitcher.SetConditionB(isLeftHeld);
            cleanerAnimSwitcher.SetConditionB(isRightHeld);
        }
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

    private void Move(int direction) // TODO separate Movement from Dialog
    {
        rotateWheel.SetRotationDirection(direction);

        if (direction != prevDirection)
        {
            hasSpokenDirection = false;
        }

        prevDirection = direction;

        float speed;

        if (direction < 0)
        {
            speed = downSpeed;

            if (!hasSpokenDirection)
            {
                AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_THIEF, AudioManager.CATEGORY_THIEF_DOWN, true);
                hasSpokenDirection = true;
            }
        }
        else
        {
            speed = upSpeed;
            if (!hasSpokenDirection)
            {
                if (direction > 0)
                {
                    AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_THIEF, AudioManager.CATEGORY_THIEF_UP, true);
                    hasSpokenDirection = true;
                }
            }
        }

        float newYPos = Mathf.Min(transform.position.y + speed * speedMultiplier * direction * Time.deltaTime, maxYPos);

        if (newYPos < minYPos + floorStopDistance)
        {
            AudioManager.Instance.ToggleLineDown(false);
        }
        else
        {
            AudioManager.Instance.ToggleLineDown(true);
        }

        newYPos = Mathf.Max(newYPos, minYPos + floorStopDistance);

        transform.position = new Vector2(transform.position.x, newYPos);

        pulleyLight.SetLight(direction);
    }
}
