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
            AudioManager.Instance.PlaySFX("Diamond");
            AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_THIEF, AudioManager.CATEGORY_THIEF_GOT_IT, true);
            Destroy(gameObject);
        }
    }
}
