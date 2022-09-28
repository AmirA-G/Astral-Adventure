using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    //I used cinemachine to control the cameras in my prototype
    public GameObject Wizard;
    public Transform tFollowTarget;
    CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {

        if (DeployAstral.astralAlive == false)
        {
            Wizard = GameObject.FindWithTag("Player"); //when the astralBody hasn't been spawned it tells the vcam to follow the main body.
            tFollowTarget = Wizard.transform;
            vcam.LookAt = tFollowTarget;
            vcam.Follow = tFollowTarget;
        }

        if (DeployAstral.astralAlive == true)
        {
            Wizard = GameObject.FindWithTag("Player1"); //when the astral body is spawned then the camera smoothly changes its focus to the astral body.
            tFollowTarget = Wizard.transform;
            vcam.LookAt = tFollowTarget;
            vcam.Follow = tFollowTarget;
        }
    }
}
