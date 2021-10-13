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
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            characterMove.UpdateKey();
        }
    }
}
