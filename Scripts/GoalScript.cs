using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    Vector3 sizeChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sizeChange.x = 0.5f * GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score;
        sizeChange.y = 0.5f * GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score;
        sizeChange.z = 0;
        transform.localScale = new Vector3(5, 5, 0) + sizeChange;
    }
}
