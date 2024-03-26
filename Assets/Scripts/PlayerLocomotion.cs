using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLocomotion : MonoBehaviour
{
    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody rigidBody;
    InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandlesAllMovement()
    {
        HandlesMovement();
        HandlesRotation();
    }
    private void HandlesMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput; //forwardmovement
        moveDirection += cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        if (PlayerManager.Instance.inputManager.moveAmount >= 0.5) //if the pos Y of the walking is 0.5 
        {
            moveDirection = moveDirection * PlayerManager.Instance.runSpeed; // the model will start the running speed
        }
        else
        {
            moveDirection = moveDirection * PlayerManager.Instance.moveSpeed;
        }

        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;
    }

    private void HandlesRotation()
    {
        Vector3 targetDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection += moveDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;
        //for rotation


        //line that makes the rotation to not reset
        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerManager.Instance.rotSpeed);
        transform.rotation = playerRotation;
    }
}
