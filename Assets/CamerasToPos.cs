using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasToPos : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    [SerializeField] float lerpSpeed = 5f;

    private bool action = false;

    private float t;

    private void Start()
    {
        t = Time.deltaTime * lerpSpeed;
    }

    private void Update()
    {
        if (action)
        {
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, t);
        }
    }

    public void Action(bool value)
    {
        action = value;
    }
}
