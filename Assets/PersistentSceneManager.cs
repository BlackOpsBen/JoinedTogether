using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersistentSceneManager : MonoBehaviour
{
    public static PersistentSceneManager Instance { get; private set; }

    private bool hasStarted = false;

    private int numFailures = 0;
    private int currentLevel = 1;

    [SerializeField] TextMeshProUGUI levelLabel;
    [SerializeField] TextMeshProUGUI failureLabel;
    [SerializeField] string levelPrefix = "Level: ";
    [SerializeField] string failurePrefix = "Failures: ";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

        UpdateUI();
    }

    public void SetHasStarted(bool value)
    {
        hasStarted = value;
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }

    public void IncreaseFailures()
    {
        numFailures++;
        UpdateUI();
    }

    public void IncreaseLevel()
    {
        currentLevel++;
        UpdateUI();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    private void UpdateUI()
    {
        levelLabel.text = levelPrefix + currentLevel.ToString();
        failureLabel.text = failurePrefix + numFailures.ToString();
    }
}
