using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeAddPuP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        DeployAstral.changeValue = DeployAstral.changeValue + 5;
    }
}
