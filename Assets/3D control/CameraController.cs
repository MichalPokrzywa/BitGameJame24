using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    InputInterface input = new StandardInput();
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;
    bool isGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        var ghostInput = gameObject.GetComponent<GhostInput>();
        if (ghostInput != null)
        {
            input = ghostInput;
            isGhost = true;
        }


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (!UIControl.isPaused)
        // {
            //mouse input
        float mouseX = input.GetMouseX() * Time.deltaTime * sensX;
        float mouseY = input.GetMouseY() * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        if (!isGhost)
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        // }
    }
}