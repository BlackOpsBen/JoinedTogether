using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] string parameterName;

    [SerializeField] Animator animator;

    private bool conditionA = false;
    private bool conditionB = false;

    public void SetConditionA(bool value)
    {
        conditionA = value;
        ToggleAnimation();
    }

    public void SetConditionB(bool value)
    {
        conditionB = value;
        ToggleAnimation();
    }

    private void ToggleAnimation()
    {
        animator.SetBool(parameterName, conditionA || conditionB);
    }
}
