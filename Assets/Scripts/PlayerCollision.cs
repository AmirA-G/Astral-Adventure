using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public static bool dashPupCollected = false;
    public bool invincible;
    public float invincibilityTime = 2f;
    public static bool exit1Found = false;
    public static bool exit2Found = false;

    void Start()
    {
        invincible = false;
    }

    //a script I created to store all collision interactions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the astral collides with the player...
        if (collision.CompareTag("Player1"))
        {
            AstralAndPlayerCollision();
        }

        //if the enemy collides with the player...
        if (collision.CompareTag("Enemy"))
        {
            DamagePlayer();
        }

        //if the player collides with the key...
        if (collision.CompareTag("Key"))
        {
            KeyFound();
        }

        //if the player collides with the Exit...
        if (collision.CompareTag("Exit"))
        {
            ExitFound();
        }

        if (collision.CompareTag("Exit2"))
        {
            ExitFound2();
        }

        if (collision.CompareTag("DashPuP"))
        {
            collapseCeiling();
        }

        if (collision.CompareTag("DescendingWall"))
        {
            squished();
        }

        if (collision.CompareTag("spikes"))
        {
            DamagePlayer();
        }

        if (collision.CompareTag("Bullet"))
        {
            DamagePlayer();
        }

        if (collision.CompareTag("Water"))
        {
            DamagePlayer();
        }

        if (collision.gameObject.layer == 7)
        {
            UIController.health = UIController.health += 1;
        }
    }

    void AstralAndPlayerCollision()
    {
        //most of these simply destroy the given object the player interacts with.
        
        DeployAstral sn = GameObject.FindObjectOfType(typeof(DeployAstral)) as DeployAstral;
        sn.DestroyAstra();
        
    }

    void DamagePlayer()
    {
        if (invincible == false)
        {
            UIController.health = UIController.health - 1; //lowers the health of the player by 1
            if (DeployAstral.astralAlive == true)
            {
                DeployAstral sn = GameObject.FindObjectOfType(typeof(DeployAstral)) as DeployAstral;
                sn.DestroyAstra(); //returns to the player once they get hit
                FindObjectOfType<AudioManager>().Play("astralDestroyed");
            }
            FindObjectOfType<AudioManager>().Play("slime");
            StartCoroutine(waitForTime());
        }
        
    }

    void KeyFound()
    {
        
        GameObject key = GameObject.FindGameObjectWithTag("Key");
        Destroy(key);
        FindObjectOfType<AudioManager>().Play("collected");
        Destroy(GameObject.FindGameObjectWithTag("PortalWall"));
    }

    void ExitFound()
    {
        Debug.Log("Stage completed");
        exit1Found = true;
        SceneManager.LoadScene(3); 
    }

    void ExitFound2()
    {
        Debug.Log("Stage completed");
        exit2Found = true;
        SceneManager.LoadScene(3);
    }

    void collapseCeiling()
    {
        GameObject powerUp = GameObject.FindGameObjectWithTag("DashPuP");
        FindObjectOfType<AudioManager>().Play("collected");
        Destroy(powerUp);
        dashPupCollected = true;
        //trap.trapTriggered = true;
        
        //transform.Translate(Vector2.up * Time.deltaTime);
    }

    void squished()
    {
        UIController.health = UIController.health - 5;
    }

    IEnumerator waitForTime()
    {
        invincible = true;
        Debug.Log(invincible);
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }
}
