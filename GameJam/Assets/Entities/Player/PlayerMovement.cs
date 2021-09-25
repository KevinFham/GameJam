using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMovement = 0f;
    bool crouchInput = false;
    bool jumpInput = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is how you debug the code; prints what's given into the Unity project console
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        horizontalMovement = Input.GetAxisRaw("Horizontal"); //Get whatever raw input is taken from the player (Left arrow or A = -1, Right arrow or D = 1)

        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouchInput = true;
        } 
        else if (Input.GetButtonUp("Crouch"))
        {
            crouchInput = false;
        }

        //If you didnt notice, Jump and Horizontal are not explicitly Space and A/D. If you go to Unity and go to Edit>Project Settings>Input you can find the input manager
    }
    
    // Added in
    void FixedUpdate()
    {
        //Not a good idea to move a character inside the Update method, which runs every frame and will probably hit performance
        //Instead we'll update movement a fixed amount of times per second
        controller.Move(horizontalMovement, crouchInput, jumpInput);
        jumpInput = false;
    }
}
