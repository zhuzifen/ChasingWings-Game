using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene1()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void SwitchScene3()
    {
        SceneManager.LoadScene(3);
    }
    public void SwitchScene4()
    {
        SceneManager.LoadScene(4);
    }
    public void SwitchSceneS() 
    {
        SceneManager.LoadScene(0);
    }
}