using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // separator in the unity inspector
    [Header("Look sensitivity")]
    public float mouseSens = 300f;

    float mouseX = 0f;
    float mouseY = 0f;

    void Start()
    {
        transform.Rotate(new Vector3(0f, 0f, 0f));
        // locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // MOUSE MOVEMENT
        mouseX += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY += -Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
