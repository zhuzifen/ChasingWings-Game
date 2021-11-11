using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCameraLogic : MonoBehaviour
{
    public Vector2 MouseStartPos;
    public Vector3 CamStartPos;
    public float Ratio = 0.01f;
    public bool isDragging;

    public int maxY = 20;
    public int minY = -8;
    public int maxZ = 75;
    public int minZ = -40;
    
    public float HoldDragFOV = 60;
    public float NormalFOV = 48;
        
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        //
        // if ((Input.GetKey(KeyCode.RightArrow) || Screen.width - mousePos.x < mouseEdgeBuffer) && getCameraPos().z <= rightEdge)
        // {
        //     transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        // }
        // if ((Input.GetKey(KeyCode.LeftArrow) || mousePos.x < mouseEdgeBuffer) && getCameraPos().z >= leftEdge)
        // {
        //     transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        // }
        // if ((Input.GetKey(KeyCode.DownArrow) || mousePos.y < mouseEdgeBuffer) && getCameraPos().y >= bottomEdge)
        // {
        //     transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        // }
        // if ((Input.GetKey(KeyCode.UpArrow) || Screen.height - mousePos.y < mouseEdgeBuffer) && getCameraPos().y <= topEdge)
        // {
        //     transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        // }

        if (Input.GetMouseButton(2) || Input.GetMouseButton(1))
        {
            
            if (isDragging == false)
            {
                isDragging = true;
                MouseStartPos = mousePos;
                CamStartPos = this.transform.position;
            }

            Vector3 diff = mousePos - MouseStartPos;
            Vector3 trans = CamStartPos - new Vector3(0, diff.y * Ratio, diff.x * Ratio);
            float newY = Mathf.Min(Mathf.Max(trans.y, minY), maxY);
            float newZ = Mathf.Min(Mathf.Max(trans.z, minZ), maxZ);
            this.transform.position = new Vector3(trans.x, newY, newZ);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, HoldDragFOV, 0.01f);
        }                                                                                        
        else                                                                                     
        {                                                                                        
            isDragging = false;                             
                        
            if (Math.Abs(Camera.main.fieldOfView - NormalFOV) > 0.01f)
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, NormalFOV, 0.03f);
            }
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
