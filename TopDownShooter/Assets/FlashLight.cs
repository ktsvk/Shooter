using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private Light2D flashlight;
    private float timePerFlash;
    private bool on = true;

    private void Start()
    {
        timePerFlash = Random.Range(0.1f, 0.4f);
    }
    void Update()
    {
        timePerFlash -= Time.deltaTime;
        if (timePerFlash <= 0)
        {
            if (on)
            {
                flashlight.enabled = false;
                on = !on;
            }
            else if (!on)
            {
                flashlight.enabled = true;
                on = !on;
            }
            timePerFlash = Random.Range(0.4f, 1f);
        }
    }
}
