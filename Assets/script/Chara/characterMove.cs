using System;
using System.Collections;
using System.Collections.Generic;
using script.Chara;
using script.User_Control;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 move = new Vector3(0, 0, 1);
    public Vector3 fanLeft = new Vector3(-1, 0, 0);
    public const float jumpForce = 1.5f;
    public const float movementSpeed = 5;
    private UserControl platformControl;

    public CharaStates characterMode = CharaStates.Stop;
    private Animator _animator;
    private switchCamera switchCamera;
    
    public bool characterHasKey = false;

    //public const int totalLife = 4;
    //public int remainLife;

    private SetupCameraLogic cameraLogic;
    public Vector3 setCameraPos = new Vector3(15, 2, 10);

    public int bonus = 0;

    private EnvironmentControl environmentControl;

    private goal goal;

    private CharaFootDetect Foot;

    // audio
    private AudioSource footStep;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        platformControl = GameObject.FindObjectOfType<UserControl>();
        switchCamera = GameObject.FindObjectOfType<switchCamera>();
        cameraLogic = GameObject.FindObjectOfType<SetupCameraLogic>();
        environmentControl = GameObject.FindObjectOfType<EnvironmentControl>();
        goal = GameObject.FindObjectOfType<goal>();
        Foot = GameObject.FindObjectOfType<CharaFootDetect>();

        footStep = GetComponent<AudioSource>();
        footStep.enabled = false;

        _animator.enabled = false;
        //remainLife = totalLife;
    }

    void OnCollisionStay(Collision coll)
    {
        if (characterMode != CharaStates.Stop && coll.gameObject.tag == "Spring")
        {
            footStep.enabled = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
    }


    // start the game play
    private void startGame()
    {
        characterMode = CharaStates.Running;
        footStep.enabled = true;
        _animator.enabled = true;
        switchCamera.startGameCamera();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("e") && !goal.GameEnded)
        {
            if (characterMode == CharaStates.Stop)
            {
                startGame();
                platformControl.startGame();
            } else
            {
                restart();
            }
        }
        if (transform.position.y < -30)
        {
            restart();
        }
        if (goal.GameEnded)
        {
            footStep.enabled = false;
            characterMode = CharaStates.Stop;
        }
    }

    void FixedUpdate()
    {
        footStep.enabled = Foot.IsTouchingGround;
        if (characterMode == CharaStates.Stop)
        {
            footStep.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
            // transform.position += move * Time.deltaTime * movementSpeed;
            if (Vector3.Dot(rb.velocity, move.normalized) < movementSpeed && Foot.IsTouchingGround)
            {
                rb.velocity += move * (movementSpeed - (Vector3.Dot(rb.velocity, move.normalized)));
            }
            // this.rb.AddForce(move * movementSpeed * Time.fixedDeltaTime * (Foot.IsTouchingGround?1:0), ForceMode.Impulse);
        }
    }
    
    public void UpdateKey()
    {
        characterHasKey = true;
    }

    // restart the game
    void restart()
    {
        footStep.enabled = false;
        _animator.Play("New State", 0, 0f);
        _animator.enabled = false;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        characterMode = CharaStates.Stop;
        cameraLogic.moveCamera(setCameraPos);
        switchCamera.setGameCamera();
        platformControl.restart();

        environmentControl.resetPosition();
        characterHasKey = false;
        bonus = 0;
    }


}

public enum CharaStates
{
    Stop,
    Running,
}