using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script.Level_Items_Script;

public class TutoralManagement : MonoBehaviour
{
    public GameObject shadowChar;
    public GameObject shadowSpring;
    public GameObject shadowFan;
    public GameObject cp1;

    public GameObject fanTutUI;

    private GameObject shadowCharNow;
    private GameObject shadowPlatformNow;
    private characterMove characterMove;

    private switchCamera switchCamera;
    private SetupCameraLogic setupCameraLogic;

    public string nowActive = "springTut";

    // Start is called before the first frame update
    void Start()
    {
        characterMove = GameObject.FindObjectOfType<characterMove>();
        switchCamera = GameObject.FindObjectOfType<switchCamera>();
        setupCameraLogic = GameObject.FindObjectOfType<SetupCameraLogic>();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stage1()
    {
        Time.timeScale = 1f;
        characterMove.setPause();
        shadowCharNow = GameObject.Instantiate(shadowChar, new Vector3(0, 0, 0.5f), Quaternion.identity);
        shadowPlatformNow = GameObject.Instantiate(shadowSpring, new Vector3(0, 0, 2), Quaternion.identity);
    }

    public void shadowCheckPoint1()
    {
        GameObject.Destroy(shadowCharNow);
        GameObject.Destroy(shadowPlatformNow);
        characterMove.resumePause();
    }

    public void checkPoint1()
    {
        GameObject.Destroy(cp1);
        switchCamera.setGameCamera();
        Time.timeScale = 0f;
        setupCameraLogic.moveCamera(new Vector3(6, 1.5f, 9));
        characterMove.setPause();
        nowActive = "fanTut";
        fanTutUI.SetActive(true);
    }

    public void stage2()
    {
        Time.timeScale = 1f;
        characterMove.setPause();
        shadowCharNow = GameObject.Instantiate(shadowChar, new Vector3(0, 1.5f, 7), Quaternion.identity);
        shadowPlatformNow = GameObject.Instantiate(shadowFan, new Vector3(0, 0.5f, 13), Quaternion.identity);
        shadowPlatformNow.GetComponent<BaseFanScript>().RotateTo(new Vector3(-90, 0, 0));
    }

    public void shadowCheckPoint2()
    {
        GameObject.Destroy(shadowCharNow);
        GameObject.Destroy(shadowPlatformNow);
        characterMove.resumePause();
    }
}
