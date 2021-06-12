using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning(gameObject.name + " detected " + collision.name);
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.LASER_INITIAL_ALERT_RATE);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogWarning(gameObject.name + " is still detecting " + collision.name);
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.LASER_CONTINUAL_ALERT_RATE * Time.deltaTime);
    }
}
