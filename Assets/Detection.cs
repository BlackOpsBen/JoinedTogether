using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.LASER_INITIAL_ALERT_RATE);

        GameManager.Instance.ShakeCamera();

        AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_THIEF, AudioManager.CATEGORY_THIEF_EXCLAIM, false);

        AudioManager.Instance.PlaySFX("Warning");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.LASER_CONTINUAL_ALERT_RATE * Time.deltaTime);
    }
}
