using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDeath : MonoBehaviour
{
    [SerializeField] float killSoundSpacing = .2f;
    [SerializeField] float killDelay = .1f;

    public bool male = false;

    public void Kill()
    {
        StartCoroutine(KillSequence());
    }

    private IEnumerator KillSequence()
    {
        yield return new WaitForSeconds(killSoundSpacing);

        if (male)
        {
            AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_GUARD2, AudioManager.CATEGORY_GUARD_DEAD, false);
        }
        else
        {
            AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_GUARD, AudioManager.CATEGORY_GUARD_DEAD, false);
        }

        yield return new WaitForSeconds(killDelay);

        AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_CLEANER, AudioManager.CATEGORY_CLEANER_KILL, true);
        Destroy(gameObject);
    }
}
