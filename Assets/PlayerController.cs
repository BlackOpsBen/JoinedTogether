using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterMovement HackerMovement;
    [SerializeField] CharacterMovement CleanerMovement;

    bool isGrabbingLeft;
    bool isGrabbingRight;

    private void Update()
    {
        HackerMovement.GrabRope(isGrabbingLeft);
        CleanerMovement.GrabRope(isGrabbingRight);
    }

    public void OnGrabLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isGrabbingLeft = true;
        }
        else if (context.canceled)
        {
            isGrabbingLeft = false;
        }
    }

    public void OnGrabLeft(bool performed)
    {
        if (performed)
        {
            isGrabbingLeft = true;
        }
        else
        {
            isGrabbingLeft = false;
        }
    }

    public void OnGrabRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isGrabbingRight = true;
        }
        else if (context.canceled)
        {
            isGrabbingRight = false;
        }
    }

    public void OnGrabRight(bool performed)
    {
        if (performed)
        {
            isGrabbingRight = true;
        }
        else
        {
            isGrabbingRight = false;
        }
    }

    public bool GetIsGrabbingRight()
    {
        return isGrabbingRight;
    }
}
