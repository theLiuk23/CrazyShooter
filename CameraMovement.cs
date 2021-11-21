using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public CharacterController controller;

    // separator in the unity inspector
    [Header("Look sensitivity")]
    public float keyboardSens = 20f;
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
        // QWEASD MOVEMENT
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");
        float keyboardY = GetUpDownMovement();

        Vector3 move = transform.right * keyboardX + transform.up * keyboardY + transform.forward * keyboardZ;
        controller.Move(move * keyboardSens * Time.deltaTime);




        // MOUSE MOVEMENT
        mouseX += Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY += -Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }

    float GetUpDownMovement()
    {
        if (Input.GetKey(KeyCode.E)) return 1f;
        if (Input.GetKey(KeyCode.Q)) return -1f;
        return 0;
    }
}
