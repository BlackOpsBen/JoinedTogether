using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCamera : MonoBehaviour
{
    [SerializeField] Collider2D detectionCollider;
    [SerializeField] GameObject[] lightObjects;
    [SerializeField] GameObject hackIcon;
    [SerializeField] GameObject hackReminder;
    [SerializeField] float thiefDistanceMax = 5f;
    [SerializeField] Transform cameraYPosMarker;

    private Transform thief;
    private Hacker hacker;

    private float timer = 0f;
    [SerializeField] private float hackTime = 2f;

    private bool isDisabled = false;

    private void Start()
    {
        thief = FindObjectOfType<ThiefMovement>().transform;
        hacker = FindObjectOfType<Hacker>();
        hackIcon.SetActive(false);
        hackReminder.SetActive(false);
    }

    private void Update()
    {
        if (!isDisabled)
        {
            if (GetIsThiefCloseEnough() && hacker.GetIsHacking())
            {
                timer += Time.deltaTime;

                hackIcon.SetActive(true);
                hackReminder.SetActive(false);
            }
            else
            {
                hackIcon.SetActive(false);
                hackReminder.SetActive(true);
            }

            if (timer > hackTime)
            {
                Disable();
            }
        }
    }

    private void Disable()
    {
        detectionCollider.enabled = false;
        for (int i = 0; i < lightObjects.Length; i++)
        {
            lightObjects[i].SetActive(false);
        }
        hackIcon.SetActive(false);
        hackReminder.SetActive(false);

        AudioManager.Instance.PlaySFX("Switch2");

        isDisabled = true;
    }

    public bool GetIsThiefCloseEnough()
    {
        return Vector2.Distance(thief.position, cameraYPosMarker.position) < thiefDistanceMax;
    }
}
