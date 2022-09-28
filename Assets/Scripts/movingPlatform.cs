using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    //source used to help make the platforms move from point to point https://youtu.be/GtX1p4cwYOc Same applies to the script elevatorCondition
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;
    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
       
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                {
                    i = 0; 
                }
            }

            if(moving == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            collision.transform.SetParent(transform);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
            moving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
