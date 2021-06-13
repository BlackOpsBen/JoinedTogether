using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private AnimationSwitcher animSwitcher;

    private bool hasStarted = false;

    private void Awake()
    {
        animSwitcher = GameObject.FindGameObjectWithTag("Hacker").GetComponent<AnimationSwitcher>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterMovement>())
        {
            Hack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AudioManager.Instance.StopSFXLoop("Hacking");

        animSwitcher.SetConditionA(false);

        hasStarted = false;
    }

    private void Hack()
    {
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.HACK_ALERT_RATE * Time.deltaTime);

        if (!hasStarted)
        {
            AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_HACKER, AudioManager.CATEGORY_HACKER_HACKING, true);
            hasStarted = true;
        }

        AudioManager.Instance.PlaySFXLoop("Hacking");

        animSwitcher.SetConditionA(true);
    }
}
