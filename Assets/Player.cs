using System.Collections;
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
    public float crouchScale = 0.6f;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    private bool isJumping;
    private bool isGrounded;

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

    void FixedUpdate()
    {
        
        
        float moveSpeed = walkSpeed;

        if (playerInput != Vector3.zero && isGrounded)
        {
            if (Input.GetKey(runKey))
            {
                moveSpeed *= 1.5f;
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
                    transform.localScale = new Vector3(1f, 1f, 1f);
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
        float distance = .75f;

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