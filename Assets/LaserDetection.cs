using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning(gameObject.name + " detected " + collision.name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogWarning(gameObject.name + " is still detecting " + collision.name);
    }
}
