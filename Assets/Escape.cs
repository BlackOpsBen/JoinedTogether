using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMovement>())
        {
            if (GameManager.Instance.GetHasObjective())
            {
                // TODO Victory stuff
                GameManager.Instance.WinLevel();
            }
            else
            {
                // TODO inform player what to do
                Debug.LogWarning("You must grab the diamond before you can leave.");
            }
        }
    }
}
