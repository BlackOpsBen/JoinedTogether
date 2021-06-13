using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour
{    
    private Cleaner cleaner;

    private Patrol patrol;

    [SerializeField] float spotDist = 1f;

    private bool alreadyRaisedAlarm = false;

    private float timer = 0f;

    private float interval = 5f;

    private void Awake()
    {
        cleaner = FindObjectOfType<Cleaner>();
        patrol = GetComponent<Patrol>();
    }

    private void Update()
    {
        UpdateTimer();

        float cleanerDist = Vector2.Distance(cleaner.transform.position, transform.position);
        if (cleanerDist < spotDist)
        {
            patrol.SetWalking(false);
            RaiseAlarm();
        }
        else
        {
            patrol.SetWalking(true);
        }
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            alreadyRaisedAlarm = false;
        }
    }

    private void RaiseAlarm()
    {
        // TODO implement spotting
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.GUARD_ALERT_RATE * Time.deltaTime);

        if (!alreadyRaisedAlarm)
        {
            AudioManager.Instance.PlayDialogOverOthers(AudioManager.CHARACTER_GUARD, AudioManager.CATEGORY_GUARD_SPOT);
            alreadyRaisedAlarm = true;
            timer = 0f;
        }
    }
}
