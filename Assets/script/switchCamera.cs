using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject setupCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        setupCamera = GameObject.Find("Setup Camera");
        mainCamera.SetActive(false);
        setupCamera.SetActive(true);
    }

    public void startGameCamera()
    {
        setupCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    public void setGameCamera()
    {
        setupCamera.SetActive(true);
        mainCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
