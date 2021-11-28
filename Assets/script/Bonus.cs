using System;
using System.Collections;
using System.Collections.Generic;
using script;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private characterMove _characterMove;

    public LevelUIScript LUIS;
    // Start is called before the first frame update
    void Start()
    {
        _characterMove = GameObject.FindObjectOfType<characterMove>();
        if (LUIS == null)
        {
            Debug.LogError("LUIS HAS NOT BEEN ASSIGNED!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _characterMove.bonus += 1;
            Debug.Log($"The Bonus {gameObject.name} has been collected.");
            if (LUIS)
            {
                LUIS.MarkCollected();
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
