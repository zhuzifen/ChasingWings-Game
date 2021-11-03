using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script.Chara;

public class charSimulate : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 move = new Vector3(0, 0, 1);
    public const float jumpForce = 7f;
    public const float movementSpeed = 5;

    public GameObject shadowPlatform;

    private Animator _animator;

    private TutoralManagement tutoralManagement;

    private CharaFootDetect Foot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.enabled = true;

        tutoralManagement = GameObject.FindObjectOfType<TutoralManagement>();
        Foot = GetComponentInChildren<CharaFootDetect>();
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Spring")
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
    }


    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "checkPoint1")
        {
            tutoralManagement.shadowCheckPoint1();
        }
        if (coll.gameObject.name == "checkPoint2")
        {
            tutoralManagement.shadowCheckPoint2();
        }
    }
    // Update is called once per frame
    private void Update()
    {

    }

    void FixedUpdate()
    {
        if (Vector3.Dot(rb.velocity, move.normalized) < movementSpeed && Foot.IsTouchingGround)
        {
            rb.velocity += move * (movementSpeed - (Vector3.Dot(rb.velocity, move.normalized)));
        }
    }
}
