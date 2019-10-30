using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    /*// Start is called before the first frame update
    //not needed right now
    void Start() {}*/

    // Update is called once per frame
    void Update()
    {
        //debug.log() to log output
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;
        if (Input.GetButtonDown("Crouch"))
            crouch = true;

    }

    private void FixedUpdate()
    {
        //move our chatracter
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
