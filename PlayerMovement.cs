using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public Animator runAnimation;
    public float keyboardSens = 20f;
    public float mouseSens = 300f;
    public float height = 3f;

    float gravity = -9.81f * 3;
    public bool isGrounded;

    public Transform groundCheck;
    public LayerMask groundMask;
    public Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        if (isGrounded && velocity.y < 0) velocity.y = -1f;

        // WASD MOVEMENT //
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");

        if (keyboardZ > 0) runAnimation.SetBool("isRunning", true);
        else runAnimation.SetBool("isRunning", false);

        Vector3 move = cameraTransform.right * keyboardX * keyboardSens + cameraTransform.forward * keyboardZ * keyboardSens;
        controller.Move(move * Time.deltaTime);

        // GRAVITY //
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        // JUMPING //
        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(height * -2f * gravity);
    }
}
