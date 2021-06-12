using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Patrol>())
        {
            Destroy(collision.gameObject);
            Debug.LogWarning(gameObject.name + " defeated " + collision.name);
        }
    }
}
