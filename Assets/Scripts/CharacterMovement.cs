using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;

    public float moveSpeed, rotSpeed;

    public float rotSmoothTime; //rotation smooth time

    public float gravityForce; //for our y

    public Animator animator; //to get Speed



    void Start()
    {
        controller = GetComponent<CharacterController>();
        //gets the game object this script is attached to and uses it for this program/code
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    public void PlayerControls()
    {
        //edit > project settings...> input manager> axes> horizontal or vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized; //normalized is added so that when you press both W and D, the movement wont be stacked


        //this is for gravity in order to check if the character is on the ground
        if (!controller.isGrounded) //you can write controller.isGrounded but !controller.isGrounded is shorter daw
        {
            movement.y -= gravityForce * Time.deltaTime; // this line gives gravity to player by giving them a fall when their y is > 0.
        }

        else
        {
            movement.y = 0; //this just puts the player o the ground
        }

        //rotation
        if(movement.magnitude > 0.1f) 
        { 
            //calculation target angle in degrees
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg; // once rotation is calculated, the rotation shall be clamped
            //clamp
            targetAngle = Mathf.Clamp(targetAngle, -180, 180); //adjust if 180 or 360 or 120 or whatever
            //smoothdamp the angle
            //                                                   smooth out y             
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotSpeed, rotSmoothTime);

            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f); // this implements the rotation transition forgot this so itr didnt rotate lol

                    

        }

        controller.Move(movement * moveSpeed * Time.deltaTime); //process the if statements first then this


        float moveMagnitude = movement.magnitude;
        animator.SetFloat("Speed", moveMagnitude);

    }
}

