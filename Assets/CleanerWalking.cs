using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerWalking : MonoBehaviour
{
    Vector2 prevPos;

    Animator animator;

    private void Start()
    {
        prevPos = transform.position;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isWalking", Vector2.Distance(transform.position, prevPos) > float.Epsilon);

        prevPos = transform.position;
    }
}
