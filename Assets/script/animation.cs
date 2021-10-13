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

    public void resetAni()
    {
        _animator.Play("New State");
        _animator.Update(0);
        _animator.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
