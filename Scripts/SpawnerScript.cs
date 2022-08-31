using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Ally;
    public GameObject Enemy;
    public GameObject Spawnpoint;
    int randomNumber;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("SpawnTimer", 5, Random.Range(0.3f,3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnTimer()
    {
        //if (GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score < 10)
            randomNumber = Random.Range(1, 3);
        //else if (GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score >= 10)
        //    randomNumber = Random.Range(1, 4);
        //else if (GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score >= 25)
        //    randomNumber = Random.Range(1, 5);

        Debug.Log(randomNumber);
        
        if(randomNumber == 1)
        {
            SpawnAlly();
        }
        else if(randomNumber == 2 || randomNumber == 3 || randomNumber == 4)
        {
            SpawnEnemy();
        }
    }

    private void SpawnAlly()
    {
        Instantiate(Ally, Spawnpoint.transform.position, new Quaternion(0, 0, 0, 0));
    }

    private void SpawnEnemy()
    {
        Instantiate(Enemy, Spawnpoint.transform.position, new Quaternion(0,0,0,0));
    }
}
