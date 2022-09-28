using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astralMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;

    // Update is called once per frame
    void Update()
    {
        //the movement script is the same as the main body as I want to disable it when the astral body is spawned. 
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && UIController.GameIsPaused == false) //astral body can jump so, when the button is pressed, jump is set to true and the animation is called
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            FindObjectOfType<AudioManager>().Play("jump");
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DamagePlayer();
        }

        if (collision.CompareTag("spikes"))
        {
            DamagePlayer();
        }

        if (collision.CompareTag("Bullet"))
        {
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        UIController.health = UIController.health - 1; //lowers the health of the player by 1
        DeployAstral sn = GameObject.FindObjectOfType(typeof(DeployAstral)) as DeployAstral;
        sn.DestroyAstra(); //returns to the player once they get hit
    }
}
