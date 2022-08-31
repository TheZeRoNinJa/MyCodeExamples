using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    Ray ray;
    public Text InteractableText;
    public RaycastHit hit;
    Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.white);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the "Press 'E' to interact" text invisible
        InteractableText.gameObject.GetComponent<Text>().color = Color.clear;

        // Interact logic
        //ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.white);

        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        // Sends out a ray that triggers interactable objects
        if (Physics.Raycast(ray, out hit, 10f))
        {
            //Debug.Log(hit.transform.name);

            if (hit.transform.tag == "Interactable")
            {
                // Raycasten reagerar med en hitbox som vi lägger på alla interactables. Denna scripten aktiverar objektens individuella scripter.
                //hit.transform.GetComponentInChildren<InteractScript>();
                hit.transform.GetComponent<InteractScript>().Interact();
                //InteractScript interactScript = GameObject.FindGameObjectWithTag(hit.transform.tag).GetComponent<InteractScript>();

                if (hit.transform.tag == "Interactable")
                {
                    InteractableText.gameObject.GetComponent<Text>().color = Color.white;
                    
                }
                //else
                //    InteractableText.gameObject.GetComponent<Text>().color = Color.clear;
            }
        }
        
    }
}
