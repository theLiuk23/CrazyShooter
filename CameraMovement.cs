using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // separator in the unity inspector
    [Header("Look sensitivity")]
    public float mouseSens = 300f;

    [Header("Objects")]
    public Transform legs;
    public Transform arms;
    public Transform body;
    public Transform head;
    float mouseX = 0f;
    float mouseY = 0f;

    void Start()
    {
        // locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
        transform.Rotate(new Vector3(0f, 0f, 0f));
    }

    void LateUpdate()
    {
        // MOUSE MOVEMENT
        mouseX += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY += -Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        // locking the rotation
        mouseY = Mathf.Clamp(mouseY, -60f, 80);

        // rotating player
        head.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        arms.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        legs.rotation = Quaternion.Euler(0f, mouseX, 0f);
        body.rotation = Quaternion.Euler(0f, mouseX, 0f);

        // rotating camera
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
