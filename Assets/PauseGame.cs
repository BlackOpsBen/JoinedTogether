using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void OnPause()
    {
        MusicManager.Instance.SwapTracks();
        Debug.LogWarning("Music swapped");
    }
}
