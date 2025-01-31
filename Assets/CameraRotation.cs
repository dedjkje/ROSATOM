using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Pause pause;

    private float mouseX;
    private float mouseY;

    [Range(50f, 500f)]
    public float sensivity = 200f;

    [Range(-90f, 90f)]
    public float minYAngle = -90f;
    [Range(-90f, 90f)]
    public float maxYAngle = 90f;

    public Transform player;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        sensivity = pause.sensitivitySlider.value;
        mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);
        rotationY += mouseX;

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        player.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}