using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] bool isLeft = false;
    [SerializeField] PlayerController playerController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isLeft)
        {
            playerController.OnGrabLeft(true);
        }
        else
        {
            playerController.OnGrabRight(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isLeft)
        {
            playerController.OnGrabLeft(false);
        }
        else
        {
            playerController.OnGrabRight(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isLeft)
        {
            playerController.OnGrabLeft(false);
        }
        else
        {
            playerController.OnGrabRight(false);
        }
    }
}
