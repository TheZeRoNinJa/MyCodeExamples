using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] Rigidbody2D rb;
    public float MoveSpeed = 0f;
    Vector3 sizeChange;

    public GameObject PauseMenu;
    public bool isPaused = false;

    public GameObject DeathMenu;

    // Start is called before the first frame update
    void Start()
    {
        sizeChange = new Vector3(0.5f, 0.5f, 0);

        //PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        //DeathMenu = GameObject.FindGameObjectWithTag("DeathMenu");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        //PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        //DeathMenu = GameObject.FindGameObjectWithTag("DeathMenu");

        rb.velocity = new Vector3(x*MoveSpeed, y*MoveSpeed);

        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Debug.Log("pause");
            PauseMenu.SetActive(true);
            isPaused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            PauseMenu.SetActive(false);
            Debug.Log("unpause");
            isPaused = false;
        }


        //Player.GetComponent<BoxCollider2D>().size = Player.transform.localScale/4;
    }

    public void UnpauseBool()
    {
        isPaused = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Player.transform.localScale.x > 0.5f)
            {
                Player.transform.localScale -= sizeChange;
                Destroy(collision.gameObject);
            }
            else
            {
                Death();
            }
        }
        else if (collision.tag == "Ally")
        {
            Player.transform.localScale += sizeChange;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Goal")
        {
            if (Player.transform.localScale.x >= collision.gameObject.transform.localScale.x)
            {
                GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().NextRound();
                GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score++;
            }
        }
    }

    private void Death()
    {
        DeathMenu.SetActive(true);
        //GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().NextRound();
        Player.SetActive(false);
        GameObject.FindGameObjectWithTag("RoundLogic").GetComponent<RoundScript>().score = 0;
    }
}
