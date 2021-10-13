using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHit : MonoBehaviour
{
    public characterMove characterMove;
    private void Start()
    {
        characterMove = FindObjectOfType<characterMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") & characterMove.characterHasKey)
        {
            Destroy(this.gameObject);
        }
    }
}
