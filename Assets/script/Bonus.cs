using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private characterMove _characterMove;
    // Start is called before the first frame update
    void Start()
    {
        _characterMove = GameObject.FindObjectOfType<characterMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            _characterMove.bonus += 1;
            Debug.Log(_characterMove.bonus);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
