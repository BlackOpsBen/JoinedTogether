using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThief : MonoBehaviour
{
    [SerializeField] Transform Thief;
    [SerializeField] float lerpSpeed = 1f;

    private void Update()
    {
        if (GameManager.Instance.GetIsPlaying())
        {
            //Vector3 lerpPos = Vector3.Lerp(transform.position, Thief.position, Time.deltaTime * lerpSpeed);
            //Vector3 newPos = new Vector3(lerpPos.x, lerpPos.y, transform.position.z);
            Vector3 newPos = new Vector3(Thief.position.x, Thief.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
