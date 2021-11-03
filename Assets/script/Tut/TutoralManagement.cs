using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        shadowCharNow = GameObject.Instantiate(shadowChar, new Vector3(0, 0, 1), Quaternion.identity);
        shadowPlatformNow = GameObject.Instantiate(shadowSpring, new Vector3(0, 0, 7), Quaternion.identity);
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
        setupCameraLogic.moveCamera(new Vector3(15, 2, 20));
        characterMove.setPause();
        fanTutUI.SetActive(true);
    }

    public void stage2()
    {
        Time.timeScale = 1f;
        characterMove.setPause();
        shadowCharNow = GameObject.Instantiate(shadowChar, new Vector3(0, 3.2f, 16), Quaternion.identity);
        shadowPlatformNow = GameObject.Instantiate(shadowFan, new Vector3(0, 1, 30), Quaternion.Euler(-90, 0, 0));
    }
}
