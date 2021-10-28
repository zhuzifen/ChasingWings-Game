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

    public void springClickNext()
    {
        springTutUI.SetActive(false);
        fanTutUI.SetActive(true);
    }
    
    public void fanClickNext()
    {
        fanTutUI.SetActive(false);
        rotateUI.SetActive(true);
    }
    
    public void rotateClickNext()
    {
        rotateUI.SetActive(false);
        deleteUI.SetActive(true);
    }
    
    public void deleteClickNext()
    {
        deleteUI.SetActive(false);
        startUI.SetActive(true);
    }
    
    public void startClickClose()
    {
        startUI.SetActive(false);
    }
}
