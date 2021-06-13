using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] string parameterName;

    [SerializeField] Animator animator;

    public void ToggleAnimation(bool value)
    {
        animator.SetBool(parameterName, value);
    }
}
