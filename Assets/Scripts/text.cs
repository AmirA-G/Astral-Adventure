using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public Image intro;
    public Image intro1;
    public Image instruct;
    public Image instruct1;

    public bool isImgOneOn;
    public bool isImgTwoOn;

    public static bool eventTriggered;

    void Awake()
    {
        intro.GetComponent<Image>().enabled = false;
        intro1.GetComponent<Image>().enabled = false;
        instruct.GetComponent<Image>().enabled = false;
        instruct1.GetComponent<Image>().enabled = false;

        if (eventTriggered == false)
        {
            Time.timeScale = 0f;
            intro.enabled = true;
            intro1.enabled = true;
            isImgOneOn = true;
            instruct.enabled = true;
            instruct1.enabled = true;
            isImgTwoOn = true;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (eventTriggered == false)
            {
                intro.enabled = false;
                instruct.enabled = false;
                instruct1.enabled = false;
                intro1.enabled = false;
                isImgOneOn = false;
                isImgTwoOn = false;
                Time.timeScale = 1f;
            }
            eventTriggered = true;
        }
    }
}
