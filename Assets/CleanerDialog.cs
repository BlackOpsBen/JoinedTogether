using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerDialog : MonoBehaviour
{
    private bool isRoping = false;
    private bool hasSpoken = true;

    [SerializeField] PlayerController playerController;

    private void SetIsRoping(bool value)
    {
        isRoping = value;
    }

    private void SetHasSpoken(bool value)
    {
        hasSpoken = value;
    }

    private void Update()
    {
        SetIsRoping(playerController.GetIsGrabbingRight());

        if (isRoping)
        {
            SetHasSpoken(false);
        }


        if (!isRoping && !hasSpoken)
        {
            AudioManager.Instance.PlayDialog(AudioManager.CHARACTER_CLEANER, AudioManager.CATEGORY_CLEANER_GO_FIGHT, true);
            SetHasSpoken(true);
        }
    }
}
