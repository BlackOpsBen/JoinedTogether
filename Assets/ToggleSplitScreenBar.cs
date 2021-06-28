using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSplitScreenBar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject instructionsUI;
    public void ToggleBar(bool value)
    {
        bar.SetActive(value);
        instructionsUI.SetActive(value);
    }
}
