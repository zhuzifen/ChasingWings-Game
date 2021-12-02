using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHit : MonoBehaviour
{
    public characterMove characterMove;
    public Animator doorOpen;
    private void Start()
    {
        characterMove = FindObjectOfType<characterMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") & characterMove.characterHasKey)
        {
            doorOpen.enabled = true;
        }
    }
}
