using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PulleyLightAndSound : MonoBehaviour
{
    [SerializeField] Sprite upSprite;
    [SerializeField] Sprite downSprite;
    [SerializeField] Sprite stopSprite;

    [SerializeField] Color[] respectiveLightColors;

    [SerializeField] SpriteRenderer sr;

    [SerializeField] Light2D light;

    private List<Sprite> lights = new List<Sprite>();

    private void Start()
    {
        lights.Add(upSprite);
        lights.Add(downSprite);
        lights.Add(stopSprite);
    }

    public void SetLight(int direction)
    {
        switch (direction)
        {
            case 1:
                ToggleSprites(0);
                AudioManager.Instance.PlaySFXLoop("Line Up");
                AudioManager.Instance.StopSFXLoop("Line Down");
                break;
            case -1:
                ToggleSprites(1);
                AudioManager.Instance.PlaySFXLoop("Line Down");
                AudioManager.Instance.StopSFXLoop("Line Up");
                break;
            case 0:
                ToggleSprites(2);
                AudioManager.Instance.StopSFXLoop("Line Up");
                AudioManager.Instance.StopSFXLoop("Line Down");
                break;
            default:
                return;
        }
    }

    private void ToggleSprites(int index)
    {
        light.color = respectiveLightColors[index];
        sr.sprite = lights[index];
    }
}
