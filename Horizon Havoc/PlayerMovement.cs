using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Getting inputs
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //Creating moving vector
        Vector3 move = transform.right * x + transform.forward * y;

        //Moving the player
        characterController.Move(move * speed * Time.deltaTime);

        //Checking if player can jump
        if(Input.GetKey(KeyCode.Space) && isGrounded ) //changed GetKeyDown to GetKey(KeyCode.Space)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * 2f * gravity); //changed -2f to 2f
        }

        //Falling down
        velocity.y -= gravity * Time.deltaTime;

        //Excuting the jump
        characterController.Move(velocity * Time.deltaTime);

        if(lastPosition != gameObject.transform.position && isGrounded == true) 
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;
    }

}
