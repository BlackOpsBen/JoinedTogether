using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRope : MonoBehaviour
{
    [SerializeField] float yPosHideThreshold = 0f;
    private SpriteRenderer sr;

    public bool debugYPos = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.enabled = transform.position.y < yPosHideThreshold;
        if (debugYPos)
        {
            Debug.LogWarning("Rope Y pos: " + transform.position.y);
        }
    }
}
