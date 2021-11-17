using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningLogic : MonoBehaviour
{
    public static bool hasWon = false;
    public GameObject WinScreenUI;

    private AudioSource footStep;

    private void Start()
    {
        footStep = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && hasWon)
        {
            SceneManager.LoadScene(1);
        }
    }

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
        footStep.enabled = false;
        Time.timeScale = 0f;
        hasWon = true;
    }
}
