using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSceneManager : MonoBehaviour
{
    public static PersistentSceneManager Instance { get; private set; }

    private bool hasStarted = false;

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
}
