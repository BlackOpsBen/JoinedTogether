using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAlertLevel : MonoBehaviour
{
    [SerializeField] RectTransform fillBar;

    private float fullHeight;

    private void Start()
    {
        fullHeight = fillBar.rect.height;
    }

    private void Update()
    {
        float t = GameManager.Instance.GetAlertLevelPercentage();

        fillBar.sizeDelta = new Vector2(fillBar.rect.width, Mathf.Lerp(0, fullHeight, t));
    }
}
