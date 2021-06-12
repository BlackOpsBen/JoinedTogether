using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private bool isWalking = true;

    private void Update()
    {
        if (isWalking)
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    public void SetWalking(bool value)
    {
        isWalking = value;
    }
}
