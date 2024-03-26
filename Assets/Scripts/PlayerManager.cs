using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; } //singleton - make sure iisa lang siya sa scene natin

    [Header("MovementStats")]
    public float moveSpeed;
    public float rotSpeed;
    public float runSpeed;

    [Header("ScriptReference")]
    public InputManager inputManager;
    public PlayerLocomotion playerLocomotion;

    [Header("Components")]
    public Rigidbody rigidBody;
    public Animator animator;

   private void Awake()
        {
        //checking if there is another player manager running in the game, if meron idedestroy, if wala, ito na yung instance
        //phase switch(?) delete the extra scripts
        //the ff lines make sure that there is only one scene
        if (Instance != null && Instance != this)
        {
            Destroy(this);
}

        else
{
    Instance = this;
}
}

// Start is called before the first frame update
void Start()
    {
    rigidBody = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
    inputManager = GetComponent<InputManager>();
    playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandlesAllMovement();
    }
}
