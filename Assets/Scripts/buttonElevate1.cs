using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonElevate1 : MonoBehaviour
{
    //another script for a button but these ones set variables in another script to true to make the platforms move.
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player1")
        {
            elevatorCondition1.buttonTest = true;
            FindObjectOfType<AudioManager>().Play("button");
        }

        if (collision.gameObject.tag == "Player")
        {
            elevatorCondition1.buttonTest = true;
            FindObjectOfType<AudioManager>().Play("button");
        }
    }
}
