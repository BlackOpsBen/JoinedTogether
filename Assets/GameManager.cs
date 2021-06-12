using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    private bool hasObjective = false;

    public bool GetHasObjective()
    {
        return hasObjective;
    }

    public void SetHasObjective(bool value)
    {
        hasObjective = value;
    }
}
