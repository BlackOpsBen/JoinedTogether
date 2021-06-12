using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    [SerializeField] float minInterval = 2f;
    [SerializeField] float maxInterval = 10f;

    private float currentInterval;
    private float timer = 0f;

    private void Start()
    {
        currentInterval = GetRandomInterval();
    }

    private float GetRandomInterval()
    {
        return UnityEngine.Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > currentInterval)
        {
            Spawn();
            timer = 0f;
            currentInterval = GetRandomInterval();
        }
    }

    private void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity, transform);
    }
}
