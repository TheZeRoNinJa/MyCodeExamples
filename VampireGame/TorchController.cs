using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    float position;
    float offset;
    public GameObject Torch;
    public GameObject Player;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Awake()
    {
        //transform.position = Player.transform.position + Offset;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Player.transform.position + Offset;
        //Debug.Break();
        //Debug.Log(transform.position);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("swing");
            GetComponent<Animator>().SetTrigger("Attacking");
        }
    }
}
