using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningLogic : MonoBehaviour
{
    public static bool hasWon = false;
    public GameObject WinScreenUI;

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.name == "goal")
        {
            Win();
        }
    }

    public void NextLevel()
    {
        WinScreenUI.SetActive(false);
        Time.timeScale = 1f;
        hasWon = false;
    }

    public void Win()
    {
        WinScreenUI.SetActive(true);
        Time.timeScale = 0f;
        hasWon = true;
    }
}
