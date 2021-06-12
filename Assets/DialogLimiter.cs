using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLimiter : MonoBehaviour
{
    private float[] timers = new float[4];
    [SerializeField] private float interval = 5f;

    private void Start()
    {
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] = 0.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime;
        }
    }

    public bool GetCanSpeak(int characterIndex)
    {
        if (timers[characterIndex] < 0.0f)
        {
            return true;
        }
        return false;
    }

    public void SetCanSpeak(int playerIndex, bool value)
    {
        if (value)
        {
            timers[playerIndex] = -1.0f;
        }
        else
        {
            timers[playerIndex] = interval;
        }
    }
}
