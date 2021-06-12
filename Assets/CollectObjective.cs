using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjective : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ThiefMovement>())
        {
            GameManager.Instance.SetHasObjective(true);
            // TODO play sound
            AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_THIEF, AudioManager.CATEGORY_THIEF_GOT_IT, true);
            // TODO trigger new music
            // TODO feedback to player to get out of there!
            Destroy(gameObject);
        }
    }
}
