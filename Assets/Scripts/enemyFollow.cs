using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{

    public float speed;
    private Transform target; //the player
    public Vector2 startPos; //stores the starting position of the enemy
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //checks whether the distance between it and the target is below 50 and if the astral body is spawned
        if(Vector2.Distance(transform.position, target.position) < 50 && DeployAstral.astralAlive == true) 
        {
            var targetPos = new Vector2(target.position.x, transform.position.y); //target position is always changing to I call it in update
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime); //moves to player
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime); //moves back to start position
        }
    }
}
