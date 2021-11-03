using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NextPage : MonoBehaviour
{
    public GameObject springTutUI;
    public GameObject fanTutUI;
    public GameObject rotateUI;
    public GameObject deleteUI;
    public GameObject startUI;

    private TutoralManagement tutoralManagement;

    private void Start()
    {
        tutoralManagement = GameObject.FindObjectOfType<TutoralManagement>();
    }

    public void springClickNext()
    {
        springTutUI.SetActive(false);
        startUI.SetActive(true);
    }
    
    public void fanClickNext()
    {
        fanTutUI.SetActive(false);
        rotateUI.SetActive(true);
    }
    
    public void rotateClickNext()
    {
        rotateUI.SetActive(false);
        tutoralManagement.stage2();
    }
    
    public void deleteClickNext()
    {
        deleteUI.SetActive(false);
        startUI.SetActive(true);
    }
    
    public void startClickClose()
    {
        startUI.SetActive(false);
        tutoralManagement.stage1();
    }
}
