using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charHitCheck : MonoBehaviour
{
    private TutoralManagement tutoralManagement;
    // Start is called before the first frame update
    void Start()
    {
        tutoralManagement = GameObject.FindObjectOfType<TutoralManagement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "checkPoint1")
        {
            tutoralManagement.checkPoint1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
