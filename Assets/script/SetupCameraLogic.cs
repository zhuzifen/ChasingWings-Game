using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCameraLogic : MonoBehaviour
{
    public int speed = 50;
    public int leftEdge = -12;
    public int rightEdge = 50;
    public int topEdge = 14;
    public int bottomEdge = -7;
    public int mouseEdgeBuffer = 50;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        if ((Input.GetKey(KeyCode.RightArrow) || Screen.width - mousePos.x < mouseEdgeBuffer) && getCameraPos().z <= rightEdge)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || mousePos.x < mouseEdgeBuffer) && getCameraPos().z >= leftEdge)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if ((Input.GetKey(KeyCode.DownArrow) || mousePos.y < mouseEdgeBuffer) && getCameraPos().y >= bottomEdge)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Screen.height - mousePos.y < mouseEdgeBuffer) && getCameraPos().y <= topEdge)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
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
