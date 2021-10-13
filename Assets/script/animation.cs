using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator _animator;
    public GameObject animationObject;
    // Start is called before the first frame update
    void Start()
    {
        _animator = animationObject.GetComponent<Animator>();
        _animator.enabled = false;
    }

    public void startAni()
    {
        _animator.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
