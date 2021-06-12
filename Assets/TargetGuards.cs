using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGuards : MonoBehaviour
{
    [SerializeField] Transform defaultDestination;

    private Cleaner cleaner;

    private List<Patrol> Guards = new List<Patrol>();

    private void Awake()
    {
        cleaner = FindObjectOfType<Cleaner>();
    }

    private void Update()
    {
        Guards = new List<Patrol>(FindObjectsOfType<Patrol>());

        if (Guards.Count == 0)
        {
            transform.position = defaultDestination.position;
        }
        else
        {
            transform.position = GetClosestGuard().transform.position;
        }
    }

    private Patrol GetClosestGuard()
    {
        float nearestDist = float.MaxValue;
        Patrol nearestGuard = Guards[0];

        for (int i = 0; i < Guards.Count; i++)
        {
            float dist = Vector2.Distance(cleaner.transform.position, Guards[i].transform.position);
            if (dist < nearestDist)
            {
                nearestDist = dist;
                nearestGuard = Guards[i];
            }
        }

        return nearestGuard;
    }
}
