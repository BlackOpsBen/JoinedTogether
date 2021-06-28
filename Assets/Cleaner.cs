using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuardDeath guard = collision.GetComponent<GuardDeath>();
        if (guard != null)
        {
            animator.SetTrigger("doPunch");
            AudioManager.Instance.PlaySFXGroup(AudioManager.SFX_GROUP_PUNCHES);
            guard.Kill();
        }
    }

    // MOVED TO GUARDDEATH
    /*public void OnAnimationEvent()
    {
        AudioManager.Instance.PlaySFXGroup(AudioManager.SFX_GROUP_PUNCHES);
        Invoke("PlayGuardSound", killSoundSpacing);

        StartCoroutine(KillSequence());
    }*/

    /*private void PlayGuardSound()
    {
        AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_GUARD, AudioManager.CATEGORY_GUARD_DEAD, false);
        Invoke("PlayCleanerSound", killSoundSpacing);
    }

    private void PlayCleanerSound()
    {
        AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_CLEANER, AudioManager.CATEGORY_CLEANER_KILL, true);
    }*/

    /*private IEnumerator KillSequence()
    {
        AudioManager.Instance.PlaySFXGroup(AudioManager.SFX_GROUP_PUNCHES);
        yield return new WaitForSeconds(killSoundSpacing);

    }*/
}
