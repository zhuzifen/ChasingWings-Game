using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHit : MonoBehaviour
{
    public characterMove characterMove;
    private void Start()
    {
        characterMove = FindObjectOfType<characterMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            characterMove.UpdateKey();
        }
    }
}
