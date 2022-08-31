using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFuelScript : MonoBehaviour
{
    TorchLightScript lightScript;
    GameObject[] Fires = new GameObject[5];
  //ParticleSystem particle = GameObject.Find("PS_Parent").GetComponent<ParticleSystem>();
    

    private void Awake()
    {
        lightScript = GameObject.FindGameObjectWithTag("TorchLight").GetComponent<TorchLightScript>();

        for (int i = 0; i < Fires.Length; i++)
        {
            string searchTag = "Fire" + (i + 1);

            Fires[i] = NewFunctions.FindChildWithTag(transform.gameObject, searchTag);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float torchLevel = lightScript.torchLevel;

        if (torchLevel >= 80)
        {
            for (int i = 0; i < Fires.Length; i++)
            {
                Fires[i].SetActive(true);
            }
        }
        else if (torchLevel >= 60)
        {
            Fires[0].SetActive(false);

            for (int i = 1; i < Fires.Length; i++)
            {
                Fires[i].SetActive(true);
            }
        }
        else if (torchLevel >= 40)
        {
            Fires[0].SetActive(false);
            Fires[1].SetActive(false);

            for (int i = 2; i < Fires.Length; i++)
            {
                Fires[i].SetActive(true);
            }
        }
        else if (torchLevel >= 20)
        {
            for (int i = 0; i < 3; i++)
            {
                Fires[i].SetActive(false);
            }

            Fires[3].SetActive(true);
            Fires[4].SetActive(true);
        }

        // find the bool in light script about whether or not the fire is active and check so that it is off
        else if (torchLevel >= 1 && lightScript.isExtinguished)
        {
            for (int i = 0; i < Fires.Length; i++)
            {
                Fires[i].SetActive(false);
            }
            Debug.Log("jooooo");
        }


    }
}
