using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TorchLightScript : MonoBehaviour
{
    public Light lightsource;
    public SphereCollider lightRadius;

    public float torchLevel;
    float lightLoss = 1;//0.25f;
    public float maxLight = 100f;
    float minLight = 1f;
    public bool LightsOut;
    GameObject torchFlame;
    public int lightRadiusGoal;
    public int lightsourceRangeGoal;
    public bool isExtinguished;


    void Awake()
    {
        torchLevel = 100f;
        lightRadius.radius = 60;

       
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (lightRadius.radius > lightRadiusGoal)
        {
            lightRadius.radius--;
        }

        if (lightsource.range > lightsourceRangeGoal && lightsource.range > 0)
        {
            lightsource.range--;
        }

        if (torchLevel > minLight)
        {
            torchLevel -= lightLoss * Time.deltaTime;
            //Debug.Log(torchLevel);
        }

        if(torchLevel <= 100 && torchLevel > 80)
        {
            lightRadiusGoal= 60;
            lightsourceRangeGoal = 28;
        }
        else if (torchLevel <= 80 && torchLevel > 60)
        {
           lightRadiusGoal = 48;
           lightsourceRangeGoal = 24;
        }
        else if (torchLevel <= 60 && torchLevel > 40)
        {
          
            lightRadiusGoal = 36;
            lightsourceRangeGoal = 20;
        }
        else if (torchLevel <= 40 && torchLevel > 20)
        {
            lightRadiusGoal = 24;
            lightsourceRangeGoal = 16;
        }
        else if (torchLevel <= 20 && torchLevel > 0)
        {
            
            lightRadiusGoal = 12;
            lightsourceRangeGoal = 12;
        }
        if (torchLevel <= minLight)
        {
           
            // Extinguishes the actual fire VFX
            ParticleSystem particle = GameObject.Find("PS_Parent").GetComponent<ParticleSystem>();
            particle.Stop();

            lightRadiusGoal = 0;
            lightsource.range = 0;
            lightsourceRangeGoal = 0;

            isExtinguished = true;


        }

        // Lights the actual fire VFX again if it is extinguished
        if(torchLevel > minLight && isExtinguished)
        {
            ParticleSystem particle = GameObject.Find("PS_Parent").GetComponent<ParticleSystem>();
            particle.Play();

            isExtinguished = false;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            lightLoss++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lightLoss--;
        }



    }

}
