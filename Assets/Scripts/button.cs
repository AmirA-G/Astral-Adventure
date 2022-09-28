using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //this is a simple button script I made early on to destroy certain objects when the player was able to reach and interact with something.
    public GameObject objectToDestroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player1")
        {
            Destroy(objectToDestroy);
            FindObjectOfType<AudioManager>().Play("button");
        }
    }
}
