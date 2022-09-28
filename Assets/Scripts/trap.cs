using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public static bool trapTriggered;
    public GameObject[] walls;
    public float Speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        trapTriggered = false;
        walls = GameObject.FindGameObjectsWithTag("DescendingWall");
    }

    // Update is called once per frame
    void Update()
    {
        if(trapTriggered == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
        }
        waitForTime();
    }

    IEnumerator waitForTime()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < 7; i++)
        {
            Destroy(walls[i]);
        }
    }
}
