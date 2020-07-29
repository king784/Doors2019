using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramPanelFollowMouse : MonoBehaviour
{
    private MouseMovement mouse;
    bool attachedToMouse = false;
    Vector3 offset;
    Camera mainCam;
    void Start()
    {
        mouse = FindObjectOfType<MouseMovement>();
        mainCam = Camera.main;
    }
    public void Clicked()
    {
        attachedToMouse = true;
        mouse.panelAttached = true;
        offset = mainCam.ScreenToWorldPoint(Input.mousePosition)-transform.parent.position;
    }

    public void Released()
    {
        attachedToMouse = false;
        mouse.panelAttached = false;
    }

    public void Update()
    {
        if(attachedToMouse)
        {
            transform.parent.position = mouse.desiredPos-offset;
        }
    }
}
