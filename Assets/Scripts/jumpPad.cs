using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public float jump;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("bouncePlant");
        }

        if (collision.gameObject.CompareTag("Player1"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("bouncePlant");
        }
    }
}
