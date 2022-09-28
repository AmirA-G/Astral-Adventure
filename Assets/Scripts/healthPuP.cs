using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPuP : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("health");
    }
}
