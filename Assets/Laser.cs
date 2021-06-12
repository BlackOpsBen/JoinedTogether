using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float onTime = 1f;
    [SerializeField] float offTime = 2f;
    [SerializeField] float offset = 0f;

    [SerializeField] GameObject laserObject;

    private float timer = 0f;

    private bool isOn = false;

    private void Start()
    {
        timer += offset;
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
    }

    private void SetIsOn()
    {
        if (timer > offTime)
        {
            isOn = true;
        }

        if (timer > offTime + onTime)
        {
            isOn = false;
            timer = 0f;
        }
    }
}
