using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSceneManager : MonoBehaviour
{
    public static PersistentSceneManager Instance { get; private set; }

    private bool hasStarted = false;

    private int numFailures = 0;
    private int currentLevel = 1;

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

        DontDestroyOnLoad(this);
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
    }

    public void IncreaseLevel()
    {
        currentLevel++;
    }
}
