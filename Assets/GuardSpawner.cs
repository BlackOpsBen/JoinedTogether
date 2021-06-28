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
        if (GameManager.Instance.GetIsPlaying())
        {
            timer += Time.deltaTime;

            if (timer > currentInterval)
            {
                Spawn();
                timer = 0f;
                currentInterval = GetRandomInterval();
            }
        }
    }

    private void Spawn()
    {
        bool male = (UnityEngine.Random.Range(0, 2) == 0);
        Instantiate(prefab, transform.position, Quaternion.identity, transform).GetComponent<GuardDeath>().male = male;
    }
}
