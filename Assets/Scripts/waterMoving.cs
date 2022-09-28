using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterMoving : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterTrigger.waterTriggered == true)
        {
            this.spriteRenderer.enabled = true;
            transform.Translate(Vector2.left * Time.deltaTime);
        }
    }
}
