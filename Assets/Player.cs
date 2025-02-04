using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Pause pause;
    public CameraRotation cameraRotation;

    public Canvas pauseMenu;
    public bool onPause = false;

    public Rigidbody rb;
    public float walkSpeed = 5f;
    public float crouchSpeed = 2f;
    Vector3 playerInput;
    Vector3 velocity;
    Vector3 velocityChange;
    public float volume = 1f;
    public bool enableJump = true;
    public float jumpPower = 5f;
    public float crouchScale = 1.5f;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public Camera playerCamera;
    DataBase data;
    private bool isJumping;
    private bool isGrounded;
    public Animator animatorButtonRight;

    public GameObject leftTumbler;
    public GameObject leftPolzunok;
    public GameObject leftKrug;
    public GameObject leftButton;
    public GameObject rightTumbler;
    public GameObject rightPolzunok;
    public GameObject rightButton;

    [SerializeField] CalculationFormulas calculationFormulas;

    private void Start()
    {
        data = GameObject.FindWithTag("ROSATOMroom").GetComponent<DataBase>();
    }
    private void Update()
    {
        
           
        volume = pause.volumeSlider.value;
        if (enableJump && Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        CheckGround();

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPause)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                onPause = false;
                cameraRotation.enabled = true;
                pauseMenu.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                onPause = true;
                cameraRotation.enabled = false;
                pauseMenu.enabled = true;
            }
        }
    }
    private void LateUpdate()
    {
        leftTumbler.SetActive(false);
        leftPolzunok.SetActive(false);
        leftKrug.SetActive(false);
        leftButton.SetActive(false);
        rightTumbler.SetActive(false);
        rightButton.SetActive(false);
        rightPolzunok.SetActive(false);

        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red);
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.transform.tag == "tumblerLeft")
            {
                leftTumbler.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (data.tumblerLeft)
                    {
                        data.tumblerLeft = false;
                    }
                    else
                    {
                        data.tumblerLeft = true;
                    }
                }
                
            }
            if (hit.transform.tag == "tumblerRight")
            {
                rightTumbler.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    if (data.tumblerRight)
                    {
                        data.tumblerRight = false;
                    }
                    else
                    {
                        data.tumblerRight = true;
                    }
                }
            }
            if (hit.transform.tag == "polzunokLeft")
            {
                leftPolzunok.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (data.polzunokLeft != 1)
                    {
                        data.polzunokLeft--;
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (data.polzunokLeft != 3)
                    {
                        data.polzunokLeft++;
                    }
                }
            }
            if (hit.transform.tag == "polzunokRight")
            {
                rightPolzunok.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (data.polzunokRight != 1)
                    {
                        data.polzunokRight--;
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (data.polzunokRight != 3)
                    {
                        data.polzunokRight++;
                    }
                }
            }
            if (hit.transform.tag == "krugLeft")
            {
                leftKrug.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (data.krugLeft != 1)
                    {
                        data.krugLeft--;
                    }
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (data.krugLeft != 3)
                    {
                        data.krugLeft++;
                    }
                }
            }
            if (hit.transform.tag == "buttonLeft")
            {
                leftButton.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    data.buttonLeft = true;
                }
                else
                {
                    data.buttonLeft = false;
                }
            }
            else
            {
                data.buttonLeft = false;

            }
            if (hit.transform.tag == "buttonRight")
            {
                rightButton.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    // Смена фильтров
                    animatorButtonRight.SetTrigger("tap");
                    calculationFormulas.radiationAround = 5f;
                }
            }
        }
    }
    void FixedUpdate()
    {
        float moveSpeed = walkSpeed;

        if (playerInput != Vector3.zero)
        {
            if (Input.GetKey(runKey))
            {
                moveSpeed *= 2f;
            }
            else
            {
                if (Input.GetKey(crouchKey))
                {
                    transform.localScale = new Vector3(1f, crouchScale, 1f);
                    moveSpeed = crouchSpeed;
                }
                else
                {
                    transform.localScale = new Vector3(1f, 3f, 1f);
                }
            }
        }

        
        playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerInput = transform.TransformDirection(playerInput) * moveSpeed;

        velocity = rb.velocity;
        velocityChange = (playerInput - velocity);
        velocityChange.y = 0;

        rb.MovePosition(rb.position + velocityChange * Time.fixedDeltaTime);
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = 2f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            Debug.DrawRay(origin, direction * distance, Color.red);
            isGrounded = true;
            isJumping = false;
        }
        else
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}