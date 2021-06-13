using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour
{    
    private Cleaner cleaner;

    private Patrol patrol;

    [SerializeField] float spotDist = 1f;

    private void Awake()
    {
        cleaner = FindObjectOfType<Cleaner>();
        patrol = GetComponent<Patrol>();
    }

    private void Update()
    {
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

    private void RaiseAlarm()
    {
        // TODO implement spotting
        GameManager.Instance.AdjustAlertLevel(GameManager.Instance.GUARD_ALERT_RATE * Time.deltaTime);
    }
}
