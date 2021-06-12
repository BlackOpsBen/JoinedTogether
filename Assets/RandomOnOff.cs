using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class RandomOnOff : MonoBehaviour
{
    [SerializeField] Color ColorA = Color.green;
    [SerializeField] Color ColorB = Color.red;

    private void Start()
    {
        int rand1 = UnityEngine.Random.Range(0, 2);

        if (rand1 == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Light2D light = GetComponent<Light2D>();
            int rand2 = UnityEngine.Random.Range(0, 2);

            if (rand2 == 0)
            {
                light.color = ColorA;
            }
            else
            {
                light.color = ColorB;
            }
        }
    }
}
