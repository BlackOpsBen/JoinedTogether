using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool hasObjective = false;

    private float alertLevel = 0f;

    private float maxAlertLevel = 100f;

    [Header("Alert Settings")]
    public float GUARD_ALERT_RATE = 1f;
    public float LASER_INITIAL_ALERT_RATE = 3f;
    public float LASER_CONTINUAL_ALERT_RATE = 1f;
    public float CAMERA_ALERT_RATE = 2f;
    public float HACK_ALERT_RATE = -1f;
    [SerializeField] float alertRateMultiplier = 1f;

    [Header("Game Setup Handling")]
    [SerializeField] GameObject splashUI;
    [SerializeField] CamerasToPos camsParent;
    [SerializeField] Animator hackerAnimController;

    [Header("Win/Lose Handling")]
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    private bool isPlaying = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
        Instance = this;
        }
    }

    public bool GetHasObjective()
    {
        return hasObjective;
    }

    public void SetHasObjective(bool value)
    {
        hasObjective = value;
        if (value)
        {
            MusicManager.Instance.SwapTracks();
        }
    }

    public float GetAlertLevelPercentage()
    {
        return alertLevel / maxAlertLevel;
    }

    public void AdjustAlertLevel(float amount)
    {
        alertLevel += amount * alertRateMultiplier;

        if (alertLevel > maxAlertLevel)
        {
            LoseLevel();
        }

        alertLevel = Mathf.Clamp(alertLevel, 0f, maxAlertLevel);
    }

    private void LoseLevel()
    {
        loseScreen.SetActive(true);
    }

    public void StartGame()
    {
        isPlaying = true;

        splashUI.SetActive(false);

        camsParent.Action(true);

        hackerAnimController.SetTrigger("startGame");
    }

    public void WinLevel()
    {
        winScreen.SetActive(true);
    }

    public bool GetIsPlaying()
    {
        return isPlaying;
    }
}
