using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool isGrabbingLeft;
    bool isGrabbingRight;

    public void OnGrabLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isGrabbingLeft = true;
            Debug.Log("Grab Left Performed: " + isGrabbingLeft);
        }
        else if (context.canceled)
        {
            isGrabbingLeft = false;
            Debug.Log("Grab Left Canceled: " + isGrabbingLeft);
        }
    }

    public void OnGrabRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isGrabbingRight = true;
            Debug.Log("Grab Right Performed: " + isGrabbingRight);
        }
        else if (context.canceled)
        {
            isGrabbingRight = false;
            Debug.Log("Grab Right Canceled: " + isGrabbingRight);
        }
    }
}
