using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundScript : MonoBehaviour
{
    
    public Text ScoreText;
    public Text HighScoreText;



    public int score = 0;
    int highScore;

    public GameObject Player;
    public GameObject Spawner;
    public GameObject Goal;

    Vector3 goalPosition;
    int goalRng;

    Vector3 spawnerPosition1;
    Vector3 spawnerPosition2;
    Vector3 spawnerPosition3;
    Vector3 spawnerPosition4;

    void Awake()
    {
        spawnerPosition1 = new Vector3(-25, 15, 0);
        spawnerPosition2 = new Vector3(-25, -9, 0);
        spawnerPosition3 = new Vector3(20, -9, 0);
        spawnerPosition4 = new Vector3(20, 15, 0);

        int score = 0;

        highScore = PlayerPrefs.GetInt("HighScore");

        NextRound();
    }

    void Update()
    {
        ScoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
        }

        HighScoreText.text = "("+highScore.ToString()+")";

        PlayerPrefs.SetInt("HighScore", highScore);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            score = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            score = 25;
        }
        
    }

    public void NextRound()
    {
        DestroyAllGameObjects();
        Redeploy();
    }

    private void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = FindObjectsOfType<GameObject>() as GameObject[];

        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].tag != "RoundLogic" && GameObjects[i].tag != "MainCamera" && GameObjects[i].tag != "Borders" && GameObjects[i].tag != "UI" && GameObjects[i].tag != "PauseMenu" && GameObjects[i].tag != "DeathMenu" && GameObjects[i].tag != "Player")
            {
                Destroy(GameObjects[i]);
            }
        }

        
    }

    /// <summary>
    /// Redeploys the player, goal and spawner GameObjects.
    /// </summary>
    private void Redeploy()
    {
        // Decides which position the goal is gonna spawn in
        goalRng = Random.Range(1, 4);
        if (goalRng == 1)
        {
            goalPosition = new Vector3(3.5f, 17.3f, 0);
        }
        else if(goalRng == 2)
        {
            goalPosition = new Vector3(4.9f, -3.7f, 0);
        }
        else if (goalRng == 3)
        {
            goalPosition = new Vector3(-8.5f, 2.4f, 0);
        }

        //Instantiate(Player, Vector3.zero, new Quaternion(0, 0, 0, 0));
        Player.transform.position = Vector3.zero;
        Player.transform.localScale = Vector3.one;
        Player.SetActive(true);

        Instantiate(Goal, goalPosition, new Quaternion(0, 0, 0, 0));

        Instantiate(Spawner, spawnerPosition1, new Quaternion(0, 0, 0.382683426f, 0.923879564f));
        Instantiate(Spawner, spawnerPosition2, new Quaternion(0, 0, 0.382683426f, 0.923879564f));
        Instantiate(Spawner, spawnerPosition3, new Quaternion(0, 0, 0.382683426f, 0.923879564f));
        Instantiate(Spawner, spawnerPosition4, new Quaternion(0, 0, 0.382683426f, 0.923879564f));


        
    }
}
