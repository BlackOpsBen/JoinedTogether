using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float onTime = 1f;
    [SerializeField] float offTime = 2f;
    [SerializeField] float offset = 0f;
    [SerializeField] bool randomInitialOffset = false;

    [SerializeField] GameObject laserObject;

    private float timer = 0f;

    private bool isOn = false;

    private bool hasPlayedSwitchSound = false;

    private void Start()
    {
        if (randomInitialOffset)
        {
            offset += UnityEngine.Random.Range(0f, 1f);
        }

        timer -= offset;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        SetIsOn();
        ToggleLaser();
    }

    private void ToggleLaser()
    {
        laserObject.SetActive(isOn);
        if (!hasPlayedSwitchSound && Vector2.Distance(laserObject.transform.position, Camera.main.transform.position) < AudioManager.LISTENING_DISTANCE)
        {
            AudioManager.Instance.PlaySFX("Switch1");
            hasPlayedSwitchSound = true;
        }
    }

    private void SetIsOn()
    {
        if (timer > offTime)
        {
            if (isOn != true)
            {
                hasPlayedSwitchSound = false;
            }

            isOn = true;
        }

        if (timer > offTime + onTime)
        {
            if (isOn != false)
            {
                hasPlayedSwitchSound = false;
            }

            isOn = false;
            timer = 0f;
        }
    }
}
