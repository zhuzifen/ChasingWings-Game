using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentControl : MonoBehaviour
{
    public GameObject key;
    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject door;

    public Vector3 keyPosition = new Vector3(0, -0.8f, 9.5f);
    public Vector3 keyRoation = new Vector3(0, 50, 0);

    public Vector3 bonus1Position = new Vector3(0, 3.8f, 10);
    public Vector3 bonus1Rotation = new Vector3(37, 0, 0);

    public Vector3 bonus2Position = new Vector3(0, 3.8f, 10);
    public Vector3 bonus2Rotation = new Vector3(37, 0, 0);

    public Vector3 doorPosition = new Vector3(0, 1.55f, 20);
    public Vector3 doorRotation = new Vector3(0, 90, 0);

    private GameObject keyNow;
    private GameObject bonus1Now;
    private GameObject bonus2Now;
    private GameObject doorNow;
    // Start is called before the first frame update
    void Start()
    {
        keyNow = GameObject.Instantiate(key, keyPosition, Quaternion.Euler(keyRoation));
        doorNow = GameObject.Instantiate(door, doorPosition, Quaternion.Euler(doorRotation));
        if (bonus1)
        {
            bonus1Now = GameObject.Instantiate(bonus1, bonus1Position, Quaternion.Euler(bonus1Rotation));
        }
        if (bonus2)
        {
            bonus1Now = GameObject.Instantiate(bonus2, bonus2Position, Quaternion.Euler(bonus2Rotation));
        }
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
        if (!bonus1Now && bonus1)
        {
            bonus1Now = GameObject.Instantiate(bonus1, bonus1Position, Quaternion.Euler(bonus1Rotation));
        }
        if (!bonus2Now && bonus2)
        {
            bonus2Now = GameObject.Instantiate(bonus2, bonus2Position, Quaternion.Euler(bonus2Rotation));
        }
        if (!doorNow)
        {
            doorNow = GameObject.Instantiate(door, doorPosition, Quaternion.Euler(doorRotation));
        }
    }
}
