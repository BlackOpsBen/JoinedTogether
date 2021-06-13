using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] float killSoundSpacing = .2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Patrol>())
        {
            Destroy(collision.gameObject);
            AudioManager.Instance.PlaySFXGroup(AudioManager.SFX_GROUP_PUNCHES);
            Invoke("PlayGuardSound", killSoundSpacing);
        }
    }

    private void PlayGuardSound()
    {
        AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_GUARD, AudioManager.CATEGORY_GUARD_DEAD, false);
        Invoke("PlayCleanerSound", killSoundSpacing);
    }

    private void PlayCleanerSound()
    {
        AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_CLEANER, AudioManager.CATEGORY_CLEANER_KILL, true);
    }
}
