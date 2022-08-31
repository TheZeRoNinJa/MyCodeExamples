using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlickerScript : MonoBehaviour
{
    public Light lightsource;
    float maxIntensity;
    float minIntensity;
    float currentIntensity;
    int upOrDown;
    float flickerAmount = 0.2f;
    GameObject torchFlame;
    public int refillCharges = 1;

    void Start()
    {
        maxIntensity = 8.0f;
        minIntensity = 4.0f;


        currentIntensity = Random.Range(minIntensity, maxIntensity);
    }

    // Update is called once per frame
    void Update()
    {
        upOrDown = Random.Range(1,3);
        if(upOrDown == 1 && lightsource.intensity > minIntensity)
        {
            lightsource.intensity -= flickerAmount;
        }
        if(upOrDown == 2 && lightsource.intensity < maxIntensity)
        {
            lightsource.intensity += flickerAmount;
        }

        //if(currentIntensity > lightsource.intensity)
        //{
        //    lightsource.intensity += 0.1f;
        //}
        //else if(currentIntensity < lightsource.intensity)
        //{
        //    lightsource.intensity -= 0.1f;
        //}
        //else
        //{
        //    currentIntensity = Random.Range(minIntensity, maxIntensity);
        //}
        //Debug.Log(lightsource.intensity);
    }
}
