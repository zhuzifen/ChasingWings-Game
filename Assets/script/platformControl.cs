using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour
{
    public GameObject character;
    public GameObject springPlatform;
    public GameObject fanPlatform;
    public GameObject fanPlatformLeft;

    private GameObject nowSelected;
    private int nowSelectedIndex;

    // a list contain all platform we make
    public List<GameObject> objectList;

    private characterMove characterMove;
    private SetupCameraLogic cameraLogic;
    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<GameObject>();
        characterMove = GameObject.FindObjectOfType<characterMove>();
        cameraLogic = GameObject.FindObjectOfType<SetupCameraLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        // we can only add platform in stop mode
        if (characterMove.characterMode == "Stop")
        {
            // add platform
            if (Input.GetKeyDown("1"))
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 mousePosOnScreen = Input.mousePosition;
                mousePosOnScreen.z = screenPos.z;
                Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
                mousePosInWorld.x = 0;
                mousePosInWorld.z += 2;
                nowSelected = GameObject.Instantiate(springPlatform, mousePosInWorld, Quaternion.identity);
                objectList.Add(nowSelected);
                nowSelectedIndex = objectList.Count - 1;
            }
            if (Input.GetKeyDown("2"))
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 mousePosOnScreen = Input.mousePosition;
                mousePosOnScreen.z = screenPos.z;
                Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
                mousePosInWorld.x = 0;
                mousePosInWorld.z += 0;
                nowSelected = GameObject.Instantiate(fanPlatform, mousePosInWorld, Quaternion.identity);
                objectList.Add(nowSelected);
                nowSelectedIndex = objectList.Count - 1;
            }

            // rotate logic
            if (Input.GetKeyDown("r"))
            {
                if (nowSelected && nowSelected.tag == "Fan")
                {
                    // if the camera at select pos, remove item, else, move camera to select pos
                    Vector3 cameraPos = cameraLogic.getCameraPos();
                    if (cameraPos.y - 5 <= nowSelected.transform.position.y && cameraPos.y + 5 >= nowSelected.transform.position.y &&
                        cameraPos.z - 5 <= nowSelected.transform.position.z && cameraPos.z + 5 >= nowSelected.transform.position.z)
                    {
                        nowSelected.transform.Rotate(new Vector3(-90f, 0f, 0f));
                    }
                    else
                    {
                        cameraLogic.moveCamera(new Vector3(10, nowSelected.transform.position.y, nowSelected.transform.position.z));
                    }
                }
            }

            // change selected logic
            if (Input.GetKeyDown("a")) {
                if (nowSelected)
                {
                    if (nowSelectedIndex > 0)
                    {
                        nowSelectedIndex -= 1;
                    } else
                    {
                        nowSelectedIndex = objectList.Count - 1;
                    }
                    nowSelected = objectList[nowSelectedIndex];
                    cameraLogic.moveCamera(new Vector3(10, nowSelected.transform.position.y, nowSelected.transform.position.z));
                } else if (objectList.Count != 0)
                {
                    nowSelectedIndex = objectList.Count - 1;
                    nowSelected = objectList[nowSelectedIndex];
                    cameraLogic.moveCamera(new Vector3(10, nowSelected.transform.position.y, nowSelected.transform.position.z));
                }
            }
            if (Input.GetKeyDown("d"))
            {
                if (nowSelected)
                {
                    if (nowSelectedIndex < objectList.Count - 1)
                    {
                        nowSelectedIndex += 1;
                    }
                    else
                    {
                        nowSelectedIndex = 0;
                    }
                    nowSelected = objectList[nowSelectedIndex];
                    cameraLogic.moveCamera(new Vector3(10, nowSelected.transform.position.y, nowSelected.transform.position.z));
                }
                else if (objectList.Count != 0)
                {
                    nowSelectedIndex = objectList.Count - 1;
                    nowSelected = objectList[nowSelectedIndex];
                    cameraLogic.moveCamera(new Vector3(10, nowSelected.transform.position.y, nowSelected.transform.position.z));
                }
            }
        }

        // delete logic
        if (Input.GetKeyDown("q"))
        {
            // remove the last object when playing
            if (characterMove.characterMode != "Stop")
            {
                GameObject lastObject = objectList[objectList.Count - 1];
                if (nowSelected == lastObject)
                {
                    nowSelected = null;
                    nowSelectedIndex = -1;
                }
                objectList.RemoveAt(objectList.Count - 1);
                GameObject.Destroy(lastObject);
            } 
            // remove selected object
            else
            {
                if (nowSelected)
                {
                    // if the camera at select pos, remove item, else, move camera to select pos
                    Vector3 cameraPos = cameraLogic.getCameraPos();
                    if (cameraPos.y - 5 <= nowSelected.transform.position.y && cameraPos.y + 5 >= nowSelected.transform.position.y &&
                        cameraPos.z - 5 <= nowSelected.transform.position.z && cameraPos.z + 5 >= nowSelected.transform.position.z)
                    {
                        objectList.Remove(nowSelected);
                        GameObject.Destroy(nowSelected);
                        nowSelected = null;
                        nowSelectedIndex = -1;
                    } else
                    {
                        cameraLogic.moveCamera(new Vector3(10, nowSelected.transform.position.y, nowSelected.transform.position.z));
                    }
                }
            }
        }
    }

    public void destroyAll()
    {
        foreach (GameObject gameObject in objectList)
        {
            GameObject.Destroy(gameObject);
        }
        objectList.Clear();
        nowSelected = null;
        nowSelectedIndex = -1;
    }
}
