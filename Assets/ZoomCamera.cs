using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] float minSize = 3f;
    [SerializeField] float maxSize = 5f;
    [SerializeField] float startZoomOutThresholdDistance = -5f;
    [SerializeField] float zoomOutSpeed = 2f;
    [SerializeField] float zoomInSpeed = 4f;

    [SerializeField] bool useOtherTransform;
    [SerializeField] Transform otherTransform;

    private Transform refTransform;

    private void Start()
    {
        if (useOtherTransform)
        {
            refTransform = otherTransform;
        }
        else
        {
            refTransform = transform;
        }
    }

    private void Update()
    {
        float currentSize = GetComponent<Camera>().orthographicSize;

        if (refTransform.position.y < startZoomOutThresholdDistance)
        {
            float t = Time.deltaTime;
            t = t * t * (3f - 2f * t);
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentSize, maxSize, t * zoomOutSpeed);
        }
        else
        {
            float newSize = currentSize - Time.deltaTime * zoomInSpeed;
            float clampedSize = Mathf.Clamp(newSize, minSize, maxSize);
            GetComponent<Camera>().orthographicSize = clampedSize;
        }
    }
}
