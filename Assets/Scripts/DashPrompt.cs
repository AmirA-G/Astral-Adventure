using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashPrompt : MonoBehaviour
{
    public Image DashInstruction;
    // Start is called before the first frame update
    void Awake()
    {
        //DashInstruction.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCollision.dashPupCollected == true)
        {
            WaitForSecond();
        }
    }

    IEnumerator WaitForSecond()
    {
        DashInstruction.GetComponent<Image>().enabled = true;
        DashInstruction.enabled = true;
        yield return new WaitForSeconds(5);
        DashInstruction.GetComponent<Image>().enabled = false;
    }
}
