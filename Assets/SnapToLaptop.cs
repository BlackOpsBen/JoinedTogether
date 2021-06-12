using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToLaptop : MonoBehaviour
{
    [SerializeField] Transform laptop;

    private void Start()
    {
        transform.position = laptop.position;
    }
}
