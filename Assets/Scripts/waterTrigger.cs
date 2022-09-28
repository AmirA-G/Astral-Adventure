using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrigger : MonoBehaviour
{
    public static bool waterTriggered;
    public GameObject trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        waterTriggered = true;
        Destroy(trigger);
    }
}
