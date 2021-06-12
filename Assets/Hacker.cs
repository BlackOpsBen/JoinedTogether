using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterMovement>())
        {
            Hack();
        }
    }

    private void Hack()
    {
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.HACK_ALERT_RATE * Time.deltaTime);
        // TODO implement hacking feedback/fx
    }
}
