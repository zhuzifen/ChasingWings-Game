using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentControl : MonoBehaviour
{
    public GameObject key;
    public GameObject memoryPiece;
    public GameObject door;

    private Vector3 keyPosition = new Vector3(0, -2, 24);
    private Vector3 keyRoation = new Vector3(0, 50, 0);

    private Vector3 memoryPiecePosition = new Vector3(0, 11, 21);
    private Vector3 memoryPieceRotation = new Vector3(37, 0, 0);

    private Vector3 doorPosition = new Vector3(0, 3.9f, 49);
    private Vector3 doorRotation = new Vector3(0, 90, 0);

    private GameObject keyNow;
    private GameObject memoryPieceNow;
    private GameObject doorNow;
    // Start is called before the first frame update
    void Start()
    {
        keyNow = GameObject.Instantiate(key, keyPosition, Quaternion.Euler(keyRoation));
        memoryPieceNow = GameObject.Instantiate(memoryPiece, memoryPiecePosition, Quaternion.Euler(memoryPieceRotation));
        doorNow = GameObject.Instantiate(door, doorPosition, Quaternion.Euler(doorRotation));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition()
    {
        if (!keyNow)
        {
            keyNow = GameObject.Instantiate(key, keyPosition, Quaternion.Euler(keyRoation));
        }
        if (!memoryPieceNow)
        {
            memoryPieceNow = GameObject.Instantiate(memoryPiece, memoryPiecePosition, Quaternion.Euler(memoryPieceRotation));
        }
        if (!doorNow)
        {
            doorNow = GameObject.Instantiate(door, doorPosition, Quaternion.Euler(doorRotation));
        }
    }
}
