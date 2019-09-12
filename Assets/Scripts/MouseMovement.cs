using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    Vector2 offset;
    Vector3 currentMousePos;
    Vector3 desiredPos;
    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        Cursor.visible = false;
    }

    void Update()
    {
        currentMousePos = Input.mousePosition;
        desiredPos = mainCam.ScreenToWorldPoint(currentMousePos);
        desiredPos.x += offset.x;
        desiredPos.y -= offset.y;
        desiredPos.z = 0.0f;
        transform.position = desiredPos;
    }
}
