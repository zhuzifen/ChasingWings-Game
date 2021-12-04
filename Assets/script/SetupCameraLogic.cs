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

    public characterMove Tracking;
    private bool HoldTracking;

    private Vector3 PreservePos = Vector3.zero;
    private bool IsMovingToPreservePos = false;

    public void RunCam(characterMove tracking)
    {
        PreservePos = this.transform.position;
        Animation ANM;
        if (this.TryGetComponent(out ANM))
        {
            Destroy(ANM);
        }
        Tracking = tracking;
    }

    public void ResetCam()
    {
        Tracking = null;
        IsMovingToPreservePos = true;
    }

    void Update()
    {
        if (Tracking != null && !HoldTracking)
        {
            this.transform.position = Vector3.Lerp(
                this.transform.position,
                new Vector3(this.transform.position.x, Tracking.transform.position.y + 1, Tracking.transform.position.z),
                0.2f
            );
        }

        MoveToPreservePosIfPossible();

        Vector2 mousePos = Input.mousePosition;
        HoldTracking = false;
        if (Input.GetMouseButton(2) || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f ||
            Mathf.Abs(Input.GetAxis("Vertical")) > 0.01f)
        {
            HoldTracking = true;
            IsMovingToPreservePos = false;
            if (isDragging == false)
            {
                isDragging = true;
                MouseStartPos = mousePos;
                CamStartPos = this.transform.position;
            }

            if (!Input.GetMouseButton(2))
            {
                CamStartPos = this.transform.position;
                MouseStartPos = mousePos;
            }

            MouseStartPos += new Vector2(
                Input.GetAxis("Horizontal") * joystickRatio * (Input.GetKey(KeyCode.Joystick1Button8) ? joystickAmplifiedRatio : 1),
                Input.GetAxis("Vertical") * joystickRatio * (Input.GetKey(KeyCode.Joystick1Button8) ? joystickAmplifiedRatio : 1)
            );
            Vector3 diff = (mousePos) - MouseStartPos;
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

    private void MoveToPreservePosIfPossible()
    {
        if (IsMovingToPreservePos)
        {
            this.transform.position = Vector3.Lerp(
                this.transform.position,
                PreservePos,
                0.03f
            );
            if ((this.transform.position - PreservePos).sqrMagnitude < 0.0003f) IsMovingToPreservePos = false;
        }
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