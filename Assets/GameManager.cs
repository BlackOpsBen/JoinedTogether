using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool hasObjective = false;

    private float alertLevel = 0f;

    private float maxAlertLevel = 100f;

    private bool alreadyWarned = false;
    private float warnThreshold = 70f;
    private float resetWarnThreshold = 50f;

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
    [SerializeField] GameObject instructionsUI;

    [Header("Win/Lose Handling")]
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    private bool isPlaying = false;

    private bool hasLostLevel = false;

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

        if (PersistentSceneManager.Instance.GetHasStarted())
        {
            StartGame();
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
            if (!hasLostLevel)
            {
                LoseLevel();
                hasLostLevel = true;
            }
        }

        alertLevel = Mathf.Clamp(alertLevel, 0f, maxAlertLevel);

        if (alertLevel > warnThreshold && !alreadyWarned)
        {
            AudioManager.Instance.PlayDialogOverOthers(AudioManager.CHARACTER_HACKER, AudioManager.CATEGORY_HACKER_WARNING);
            alreadyWarned = true;
        }

        if (alertLevel < resetWarnThreshold)
        {
            alreadyWarned = false;
        }
    }

    public void StartGame()
    {
        isPlaying = true;

        splashUI.SetActive(false);

        camsParent.Action(true);

        hackerAnimController.SetTrigger("startGame");

        PersistentSceneManager.Instance.SetHasStarted(true);

        instructionsUI.SetActive(true);
    }

    public void WinLevel()
    {
        winScreen.SetActive(true);
        PersistentSceneManager.Instance.IncreaseLevel();
        Invoke("Restart", 1f);
    }

    private void LoseLevel()
    {
        loseScreen.SetActive(true);
        PersistentSceneManager.Instance.IncreaseFailures();
        Invoke("Restart", 1f);
    }

    public bool GetIsPlaying()
    {
        return isPlaying;
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
