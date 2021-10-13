using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 move = new Vector3(0, 0, 1);
    public Vector3 fanLeft = new Vector3(-1, 0, 0);
    public const float jumpForce = 1f;
    public const float movementSpeed = 5;
    private platformControl platformControl;

    public string characterMode = "Stop";
    private Animator _animator;
    private switchCamera switchCamera;
    
    public bool characterHasKey = false;

    public const int totalLife = 4;
    public int remainLife;

    private SetupCameraLogic cameraLogic;
    public Vector3 setCameraPos = new Vector3(10, 2, 10);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        platformControl = GameObject.FindObjectOfType<platformControl>();
        switchCamera = GameObject.FindObjectOfType<switchCamera>();
        cameraLogic = GameObject.FindObjectOfType<SetupCameraLogic>();

        _animator.enabled = false;
        remainLife = totalLife;
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Spring")
        {
            characterMode = "Running";
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
        if (characterMode == "OnWind" && coll.gameObject.tag == "Running")
        {
            characterMode = "Running";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fan")
        {
            if (characterMode == "Running")
            {
                characterMode = "OnWind";
                transform.position += move * Time.deltaTime * movementSpeed * 5;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // running = true;
        if (other.gameObject.tag == "Fan" && characterMode != "Stop")
        {
            characterMode = "OnWind";
            Vector3 fanRotation = other.gameObject.transform.rotation.eulerAngles;
            if (fanRotation == new Vector3(270f, 0f, 0f))
            {
                rb.velocity = new Vector3(0, 10, 0);
            }
            if (fanRotation == new Vector3(0f, 180f, 180f))
            {
                rb.velocity = new Vector3(0, 0, -10);
            }
            if (fanRotation == new Vector3(0f, 0f, 0f))
            {
                rb.velocity = new Vector3(0, 0, 10);
            }
            if (fanRotation == new Vector3(90f, 0f, 0f))
            {
                rb.velocity = new Vector3(0, -10, 0);
            }
        }
    }

    // start the game play
    private void startGame()
    {
        characterMode = "Running";
        _animator.enabled = true;
        switchCamera.startGameCamera();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            startGame();
        }
        if (transform.position.y < -30)
        {
            remainLife -= 1;
            if (remainLife == 0)
            {
                gameOver();
            } else
            {
                restart();
            }
        }
    }

    void FixedUpdate()
    {
        if (characterMode == "Stop")
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
        if (characterMode == "Running")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
            transform.position += move * Time.deltaTime * movementSpeed;
        }
    }
    
    public void UpdateKey()
    {
        characterHasKey = true;
    }

    // restart the game
    void restart()
    {
        _animator.enabled = false;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        characterMode = "Stop";
        cameraLogic.moveCamera(setCameraPos);
        switchCamera.setGameCamera();
    }

    // when you lose all your life
    void gameOver()
    {
        _animator.enabled = false;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        characterMode = "Stop";
        platformControl.destroyAll();
        cameraLogic.moveCamera(setCameraPos);
        switchCamera.setGameCamera();
        Time.timeScale = 0;
    }
}