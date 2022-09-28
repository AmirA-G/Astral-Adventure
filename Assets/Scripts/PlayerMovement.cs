using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Link to Youtube video
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 50f;
    public bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && UIController.GameIsPaused == false) //by pressing the Jump between, in most cases this is set to spacebar. 
            
        {
            jump = true;
            animator.SetBool("IsJumping", true); //It will set jump as true and let the animator know to run an animation
            FindObjectOfType<AudioManager>().Play("jump");
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false); //When the player lands on the ground it will switch back to the idle or run animation 
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); 
        jump = false;
    }
}
