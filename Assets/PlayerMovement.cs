using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public Animator animator;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    /*// Start is called before the first frame update
    //not needed right now
    void Start() {}*/

    // Update is called once per frame
    void Update()
    {
        //debug.Log() to log output
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = rb.velocity.y;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetFloat("Vertical", verticalMove);
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
        Debug.Log(crouch);

    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
    private void FixedUpdate()
    {
        //move our chatracter
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
