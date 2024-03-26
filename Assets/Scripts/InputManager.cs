using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public Vector2 movementInput;

    public float horizontalInput;
    public float verticalInput;

    public float moveAmount;


    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();
            playerInput.PlayerMovement.Keyboard.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable(); 
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprinting();
    }

    private void HandleMovementInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
    }

    private void HandleSprinting()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
