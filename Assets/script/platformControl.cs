using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour
{
    public GameObject character;
    public GameObject springPlatform;
    public GameObject fanPlatform;

    private GameObject nowSelected;
    private int nowSelectedIndex;

    // a list contain all platform we make
    public List<GameObject> objectList;

    private characterMove characterMove;
    private SetupCameraLogic cameraLogic;

    public const int springLimit = 2;
    public int springCount = 0;

    public const int fanLimit = 4;
    public int fanCount = 0;

    public Material normal;
    public Material fanSelected;
    public Material springSelected;
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
            if (Input.GetKeyDown("1") && springCount < springLimit)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 mousePosOnScreen = Input.mousePosition;
                mousePosOnScreen.z = screenPos.z;
                Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
                mousePosInWorld.x = 0;
                mousePosInWorld.z += 2;

                GameObject previousSelected = nowSelected;
                nowSelected = GameObject.Instantiate(springPlatform, mousePosInWorld, Quaternion.identity);
                updateSelectMat(previousSelected, nowSelected);

                objectList.Add(nowSelected);
                nowSelectedIndex = objectList.Count - 1;
                springCount += 1;
            }
            if (Input.GetKeyDown("2") && fanCount < fanLimit)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 mousePosOnScreen = Input.mousePosition;
                mousePosOnScreen.z = screenPos.z;
                Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
                mousePosInWorld.x = 0;
                mousePosInWorld.z += 0;

                GameObject previousSelected = nowSelected;
                nowSelected = GameObject.Instantiate(fanPlatform, mousePosInWorld, Quaternion.identity);
                updateSelectMat(previousSelected, nowSelected);

                objectList.Add(nowSelected);
                nowSelectedIndex = objectList.Count - 1;
                fanCount += 1;
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
                        cameraLogic.moveCamera(new Vector3(15, nowSelected.transform.position.y, nowSelected.transform.position.z));
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
                    GameObject previousSelected = nowSelected;
                    nowSelected = objectList[nowSelectedIndex];
                    updateSelectMat(previousSelected, nowSelected);
                    cameraLogic.moveCamera(new Vector3(15, nowSelected.transform.position.y, nowSelected.transform.position.z));
                } else if (objectList.Count != 0)
                {
                    nowSelectedIndex = objectList.Count - 1;
                    GameObject previousSelected = nowSelected;
                    nowSelected = objectList[nowSelectedIndex];
                    updateSelectMat(previousSelected, nowSelected);
                    cameraLogic.moveCamera(new Vector3(15, nowSelected.transform.position.y, nowSelected.transform.position.z));
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
                    GameObject previousSelected = nowSelected;
                    nowSelected = objectList[nowSelectedIndex];
                    updateSelectMat(previousSelected, nowSelected);
                    cameraLogic.moveCamera(new Vector3(15, nowSelected.transform.position.y, nowSelected.transform.position.z));
                }
                else if (objectList.Count != 0)
                {
                    nowSelectedIndex = objectList.Count - 1;
                    GameObject previousSelected = nowSelected;
                    nowSelected = objectList[nowSelectedIndex];
                    updateSelectMat(previousSelected, nowSelected);
                    cameraLogic.moveCamera(new Vector3(15, nowSelected.transform.position.y, nowSelected.transform.position.z));
                }
            }
        }

        // delete logic
        if (Input.GetKeyDown("q"))
        {
            // remove the last object when playing
            if (characterMove.characterMode != "Stop")
            {
                if (objectList.Count != 0)
                {
                    GameObject lastObject = objectList[objectList.Count - 1];
                    if (nowSelected == lastObject)
                    {
                        nowSelected = null;
                        nowSelectedIndex = -1;
                    }
                    if (lastObject.tag == "Fan")
                    {
                        fanCount -= 1;
                    }
                    else if (lastObject.tag == "SpringPlatform")
                    {
                        springCount -= 1;
                    }
                    objectList.RemoveAt(objectList.Count - 1);
                    GameObject.Destroy(lastObject);
                    if (objectList.Count != 0)
                    {
                        updateSelectMat(null, objectList[objectList.Count - 1]);
                    }
                }
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
                        if (nowSelected.tag == "Fan")
                        {
                            fanCount -= 1;
                        }
                        else if (nowSelected.tag == "SpringPlatform")
                        {
                            springCount -= 1;
                        }
                        objectList.Remove(nowSelected);
                        GameObject.Destroy(nowSelected);
                        nowSelected = null;
                        nowSelectedIndex = -1;
                    } else
                    {
                        cameraLogic.moveCamera(new Vector3(15, nowSelected.transform.position.y, nowSelected.transform.position.z));
                    }
                }
            }
        }
    }

    // update select outline
    private void updateSelectMat(GameObject previousSelect, GameObject nowSelect)
    {
        if (previousSelect && previousSelect.tag == "Fan")
        {
            previousSelect.transform.Find("FRAME").GetComponent<Renderer>().material = normal;
        }
        else if (previousSelect && previousSelect.tag == "SpringPlatform")
        {
            previousSelect.transform.Find("Platform").GetComponent<Renderer>().material = normal;
        }
        if (nowSelect && nowSelect.tag == "Fan")
        {
            nowSelect.transform.Find("FRAME").GetComponent<Renderer>().material = fanSelected;
        }
        else if (nowSelect && nowSelect.tag == "SpringPlatform")
        {
            nowSelect.transform.Find("Platform").GetComponent<Renderer>().material = springSelected;
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
        fanCount = 0;
        springCount = 0;
    }

    public void startGame()
    {
        if (objectList.Count != 0)
        {
            updateSelectMat(nowSelected, objectList[objectList.Count - 1]);
        }
    }

    public void restart()
    {
        resetSpring();
        if (objectList.Count != 0)
        {
            updateSelectMat(objectList[objectList.Count - 1], nowSelected);
        }
        else
        {
            updateSelectMat(null, nowSelected);
        }
    }

    private void resetSpring()
    {
        foreach (GameObject gameObject in objectList)
        {
            if (gameObject.tag == "SpringPlatform")
            {
                Animator springAnimator = gameObject.GetComponent<Animator>();
                springAnimator.Play("New State", 0, 0f);
                springAnimator.Update(0);
                springAnimator.enabled = false;
            }
        }
    }
}
