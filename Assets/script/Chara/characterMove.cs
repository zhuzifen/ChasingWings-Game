using System;
using System.Collections;
using System.Collections.Generic;
using script;
using script.Chara;
using script.UI;
using script.User_Control;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 moveDir = new Vector3(0, 0, 1);
    [HideInInspector]
    public Vector3 move = new Vector3(0, 0, 1);
    public int deathDepth = -7;
    // public const float jumpForce = 3.5f;
    public const float movementSpeed = 3;
    private UserControl platformControl;

    public CharaStates characterMode = CharaStates.Stop;
    public Animator animator;
    
    
    public bool characterHasKey = false;

    //public const int totalLife = 4;
    //public int remainLife;

    private SetupCameraLogic cameraLogic;
    public Vector3 setCameraPos = new Vector3(6, 1, 4);

    public int bonus = 0;

    private EnvironmentControl environmentControl;

    private goal goal;

    private CharaFootDetect Foot;

    // audio
    public AudioSource footStep;
    public AudioSource landingSound;

    private PauseMenu pauseMenu;
    public GameObject stonePointer;

    public DualPurposeCursor DPCursor;
    // Start is called before the first frame update
    void Start()
    {        

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        platformControl = GameObject.FindObjectOfType<UserControl>();
        cameraLogic = GameObject.FindObjectOfType<SetupCameraLogic>();
        environmentControl = GameObject.FindObjectOfType<EnvironmentControl>();
        goal = GameObject.FindObjectOfType<goal>();
        Foot = GetComponentInChildren<CharaFootDetect>();
        DPCursor = GameObject.FindObjectOfType<DualPurposeCursor>();
        pauseMenu = FindObjectOfType<PauseMenu>();

        footStep = GetComponents<AudioSource>()[0];
        footStep.enabled = false;
        landingSound = GetComponents<AudioSource>()[1];
        landingSound.enabled = false;

        animator.Play("idle");
        //remainLife = totalLife;
        GameStateChecker.RespawnCount = 0;
    }

    void OnCollisionStay(Collision coll)
    {
        // if (characterMode != CharaStates.Stop && coll.gameObject.tag == "Spring")
        // {
        //     footStep.enabled = false;
        //     rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        //     animation animation = coll.gameObject.GetComponent<animation>();
        //     animation.startAni();
        // }
    }


    // start the game play
    private void startGame()
    {
        characterMode = CharaStates.Running;
        footStep.enabled = true;
        animator.Play("running");
        cameraLogic.RunCam(this);
        Time.timeScale = 1;
        if (stonePointer)
        {
            // stonePointer.SetActive(true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (DPCursor.StartPressed && !goal.GameEnded)
        {
            TriggerStart();
        }
        if (transform.position.y < deathDepth)
        {
            restart();
        }
        //if (goal.GameEnded)
        //{
        //    footStep.enabled = false;
        //    characterMode = CharaStates.Stop;
        //}
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) && !pauseMenu.isPaused)
        {
            pauseMenu.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button7) && pauseMenu.isPaused)
        {
            pauseMenu.Resume();
        }
    }

    void FixedUpdate()
    {
        AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        bool playingFalling = stateinfo.IsName("falling");
        bool playingLanding = stateinfo.IsName("landing");
        if (characterMode == CharaStates.Running && !Foot.IsTouchingGround && !playingFalling)
        {
            animator.Play("falling");
        }
        if (characterMode == CharaStates.Running && Foot.IsTouchingGround && playingFalling)
        {
            landingSound.enabled = true;
            landingSound.Play();
            animator.Play("landing");
        }
        if (characterMode == CharaStates.Running && Foot.IsTouchingGround && !playingLanding)
        {
            footStep.enabled = true;
        } else
        {
            footStep.enabled = false;
        }
        if (characterMode != CharaStates.Running)
        {
            footStep.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else if (characterMode == CharaStates.Running)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
            // transform.position += move * Time.deltaTime * movementSpeed;
            if (Vector3.Dot(rb.velocity, move.normalized) < movementSpeed && Foot.IsTouchingGround)
            {
                rb.velocity += move * (movementSpeed - (Vector3.Dot(rb.velocity, move.normalized)));
            }
            // this.rb.AddForce(move * movementSpeed * Time.fixedDeltaTime * (Foot.IsTouchingGround?1:0), ForceMode.Impulse);
        }

        GameStateChecker.isTheCharaMoving = (characterMode != CharaStates.Stop);
    }
    
    public void UpdateKey()
    {
        characterHasKey = true;
    }

    public void TriggerStart()
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

    // restart the game
    void restart()
    {
        GameStateChecker.RespawnCount += 1;
        footStep.enabled = false;
        animator.Play("idle");
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        move = moveDir;
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        characterMode = CharaStates.Stop;
        cameraLogic.ResetCam();
        platformControl.restart();

        if (environmentControl)
        {
            environmentControl.resetPosition();
        }
        if (stonePointer)
        {
            // stonePointer.SetActive(false);
        }
        characterHasKey = false;
        bonus = 0;
    }
    
    public void setPause()
    {
        characterMode = CharaStates.Pause;
        cameraLogic.Tracking = null;
        footStep.enabled = false;
        animator.Play("idle");
    }

    public void resumePause()
    {
        characterMode = CharaStates.Stop;
    }
}

public enum CharaStates
{
    Stop,
    Running,
    Pause
}
