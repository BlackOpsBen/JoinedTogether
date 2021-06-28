using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    private int direction = 0;
    [SerializeField] float rotationSpeed = 1f;

    public void SetRotationDirection(int direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Time.deltaTime * direction * rotationSpeed);
    }
}
