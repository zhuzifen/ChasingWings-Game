using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupCameraLogic : MonoBehaviour
{
    public Vector2 MouseStartPos;
    public Vector3 CamStartPos;
    public float Ratio = 0.01f;
    public float joystickRatio = 1;
    public float joystickAmplifiedRatio = 3;
    public bool isDragging;

    public int maxY = 20;
    public int minY = -8;
    public int maxZ = 75;
    public int minZ = -40;

    public float MaxFOV = 60;
    public float NormalFOV = 48;

    public Image CursorImage;

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetMouseButton(2) || Input.GetMouseButton(1) || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f ||
            Mathf.Abs(Input.GetAxis("Vertical")) > 0.01f)
        {
            if (isDragging == false)
            {
                isDragging = true;
                MouseStartPos = mousePos;
                CamStartPos = this.transform.position;
            }
            MouseStartPos += new Vector2(
                Input.GetAxis("Horizontal") * joystickRatio * (Input.GetKey(KeyCode.Joystick1Button8) ? joystickAmplifiedRatio : 1),
                Input.GetAxis("Vertical") * joystickRatio * (Input.GetKey(KeyCode.Joystick1Button8) ? joystickAmplifiedRatio : 1)
            );
            
            Vector3 diff = mousePos - MouseStartPos;
            var trans = CamStartPos - new Vector3(
                0,
                diff.y * Ratio,
                diff.x * Ratio
            );
            float newY = Mathf.Clamp(trans.y, minY, maxY);
            float newZ = Mathf.Clamp(trans.z, minZ, maxZ);
            this.transform.position = new Vector3(this.transform.position.x, newY, newZ);
        }
        else
        {
            isDragging = false;
        }


        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - Input.mouseScrollDelta.x - Input.mouseScrollDelta.y, NormalFOV, MaxFOV);
    }

    public void moveCamera(Vector3 position)
    {
        transform.position = position;
    }

    public Vector3 getCameraPos()
    {
        return transform.position;
    }
}