using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCollision.dashPupCollected == true && DeployAstral.astralAlive == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                FindObjectOfType<AudioManager>().Play("dash");
                if (dashTime <= 0)
                {
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (CharacterController2D.directionCheck == false)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (CharacterController2D.directionCheck == true)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }

                }
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
