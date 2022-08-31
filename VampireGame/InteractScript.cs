using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    GameObject player;
    string objectType;
    public Image DemoImage;
    public Text DemoText;
    public int RefillCharges;

    // Start is called before the first frame update
    void Start()
    {
        //DemoImage.color = Color.clear;
        //DemoText.color = Color.clear;
        RefillCharges = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Finds the tag of the object the player is looking at. If the player presses 'E' it runs the function associated with the object.
    /// </summary>
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("1");
            //player = GameObject.FindGameObjectWithTag("Player");
            objectType = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteract>().hit.transform.parent.tag;

            if (objectType == "WallTorch")
            {
                //Debug.Log("2");
                WallTorchFunction();

            }

            if (objectType == "Ladder")
            {
                LadderFunction();
            }
        }
    }

    /// <summary>
    /// Refills the torch meter
    /// </summary>
    public void WallTorchFunction()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        TorchLightScript torchLightScript = GameObject.FindGameObjectWithTag("TorchLight").GetComponent<TorchLightScript>();
        
        
        Light wallTorchLight = GameObject.FindGameObjectWithTag("WallTorch").GetComponent<Light>();
        Light playerTorchLight = GameObject.FindGameObjectWithTag("TorchLight").GetComponent<Light>();

        


        if (RefillCharges > 0)
        {
            if (torchLightScript.torchLevel <= 80)
            {
                torchLightScript.torchLevel += 20;
                RefillCharges--;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteract>().hit.transform.parent.GetComponent<Light>().color = playerTorchLight.color;
            }
            else
            {
                torchLightScript.torchLevel = 100;
                RefillCharges--;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteract>().hit.transform.parent.GetComponent<Light>().color = playerTorchLight.color;
            }
            
        }
        else
        {

        }
    }

    public void LadderFunction()
    {
        GameObject.FindGameObjectWithTag("Ladder").GetComponent<SceneSwitcher>().SceneSwitch();
    }

}


