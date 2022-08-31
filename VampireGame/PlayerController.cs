using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public float MovementSpeed;
    public float AttackRange;
    public Vector3 Velocity;
    private Camera playerCamera;
    private CharacterController characterController;
    private bool isMoving;
    private GameObject enemy;
    bool isPlayingWalkingSounds = false;

    public AudioSource BreathingSounds;
    public AudioSource WalkingSounds;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Health = MaxHealth;
        isMoving = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        BreathingSounds.Play();
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        CalculateMovement(ref Velocity);

        characterController.Move(Velocity);
    }

    private void Update()
    {
        //Debug.Log("Health: " + Health);
    }

    /// <summary>
    /// Calculates how the player is supposed to move
    /// </summary>
    /// <param name="objectVector">The vector where the calculated data is stored</param>
    private void CalculateMovement(ref Vector3 objectVector)
    {
        //Ensures that the player always faces the same direction as the camera
        //transform.forward = playerCamera.transform.forward;
        transform.forward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);
        transform.right = playerCamera.transform.right;
        //Debug.Log(transform.forward);

        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(transform.forward * MovementSpeed * Time.deltaTime);
            isMoving = true;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(-transform.right * MovementSpeed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-transform.forward * MovementSpeed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(transform.right * MovementSpeed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("Epic");
            Attack();
        }
        //isMoving = false;

        if (isMoving && !isPlayingWalkingSounds)
        {
            WalkingSounds.Play();
            isPlayingWalkingSounds = true;
        }
        if (characterController.velocity == Vector3.zero)
        {
            WalkingSounds.Stop();
            isPlayingWalkingSounds = false;
        }
        
        
    }


    public void Attack()
    {
        Vector3 dir = enemy.transform.position - transform.position;

        Ray ray = new Ray(transform.position, dir);

        RaycastHit hit;

        //GetComponent<Animator>().SetTrigger("Attacking");

        if (Physics.Raycast(ray, out hit, AttackRange) && hit.transform.tag == "Enemy")
        {
            enemy.GetComponent<NavigationScript>().Stun();
        }

    }

}
