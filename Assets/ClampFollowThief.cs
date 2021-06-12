using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampFollowThief : MonoBehaviour
{
    [SerializeField] float offset;
    [SerializeField] float clampMin;
    [SerializeField] float clampMax;
    [SerializeField] GameObject parentToFollow;

    private ToggleSplitScreenBar bar;

    private void Start()
    {
        bar = GetComponent<ToggleSplitScreenBar>();
    }

    private void Update()
    {
        float clampedYPos = Mathf.Clamp(parentToFollow.transform.position.y + offset, clampMin, clampMax);
        transform.position = new Vector3(transform.position.x, clampedYPos, transform.position.z);

        bar.ToggleBar(clampedYPos == clampMin);
    }
}
