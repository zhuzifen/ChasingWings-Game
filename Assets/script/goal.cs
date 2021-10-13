using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject g;
    public bool GameEnded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hint!!!!!");
        Destroy(g);
        EndGame();
    }
    private void EndGame()
    {
        GameEnded = true;
        Time.timeScale = 0;
        Debug.Log("Game has ended.");
    }
}
