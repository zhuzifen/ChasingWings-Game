using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentControl : MonoBehaviour
{
    public GameObject key;
    public GameObject memoryPiece;

    private Vector3 keyPosition = new Vector3(0, -1, 24);
    private Vector3 keyRoation = new Vector3(50, 0, -53);

    private Vector3 memoryPiecePosition = new Vector3(0, -8, 21);
    private Vector3 memoryPieceRotation = new Vector3(37, 0, 0);

    private GameObject keyNow;
    private GameObject memoryPieceNow;
    // Start is called before the first frame update
    void Start()
    {
        keyNow = GameObject.Instantiate(key, keyPosition, Quaternion.Euler(keyRoation));
        memoryPieceNow = GameObject.Instantiate(memoryPiece, memoryPiecePosition, Quaternion.Euler(memoryPieceRotation));
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
    }
}
