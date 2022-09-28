using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool exitSpawned;
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        exitSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollision.exit1Found == true)
        {
            PlayerCollision.exit1Found = true;
        }

        if (PlayerCollision.exit2Found == true)
        {
            PlayerCollision.exit2Found = true;
        }

        if (PlayerCollision.exit1Found == true && PlayerCollision.exit2Found == true)
        {
            this.spriteRenderer.enabled = true;
            exitSpawned = true;
        }

        if(exitSpawned == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
