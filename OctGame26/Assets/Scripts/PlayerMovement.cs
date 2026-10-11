using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;




    private float smoothTurnVelocity;
    public float smoothTurnTime = 0.1f;
    public Transform camera;


    public Animator animator;
    private bool isWalking = false;
    private bool hasJumped = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        ProcessAnimations();
    }

    public void ProcessMovement(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;


        //If Player is moving
        if(moveDirection.magnitude >= 0.1f)
        {
            //Calculate angle between Player direction and Travel direction + direction of camera
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + camera.eulerAngles.y;

            //Calculates angles to create a smooth turning effect for the player (player direction, target angle, variable to store current angle, turn speed)
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Calculate new direction based off the camera direction
            Vector3 targetDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //Move Player
            controller.Move(targetDirection.normalized * speed * Time.deltaTime);

            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        ProcessGravity();
    }

    private void ProcessGravity()
    {
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
            hasJumped = false;
        }
            

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void ProcessJump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            hasJumped = true;
        }
    }

    private void ProcessAnimations()
    {
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("HasJumped", hasJumped);
        
    }
}
