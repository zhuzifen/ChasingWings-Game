using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCameraLogic : MonoBehaviour
{
    public int speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
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
