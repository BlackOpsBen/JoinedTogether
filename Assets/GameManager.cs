using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool hasObjective = false;

    private float alertLevel = 0f;

    private float maxAlertLevel = 100f;

    public float GUARD_ALERT_RATE = 1f;
    public float LASER_INITIAL_ALERT_RATE = 3f;
    public float LASER_CONTINUAL_ALERT_RATE = 1f;
    public float CAMERA_ALERT_RATE = 2f;
    public float HACK_ALERT_RATE = -1f;
    [SerializeField] float alertRateMultiplier = 1f;

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
    }

    public float GetAlertLevelPercentage()
    {
        return alertLevel / maxAlertLevel;
    }

    public void AdjustAlertLevel(float amount)
    {
        alertLevel += amount * alertRateMultiplier;
        alertLevel = Mathf.Clamp(alertLevel, 0f, maxAlertLevel);
    }
}
