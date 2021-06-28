using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] GameObject pauseScreen;
    public void OnPause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseScreen.SetActive(true);
        }
    }
}
