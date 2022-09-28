using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableCheck : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        UIController.collectable = UIController.collectable + 1;
        FindObjectOfType<AudioManager>().Play("collected");
    }
}
