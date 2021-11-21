using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float keyboardSens = 20f;
    public float mouseSens = 300f;
    public float height = 3f;

    float gravity = -9.81f * 3;
    bool isGrounded = true;

    public Transform groundCheck;
    public LayerMask groundMask;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        if (isGrounded && velocity.y < 0) velocity.y = -1f;

        // WASD MOVEMENT
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * keyboardX * keyboardSens + transform.forward * keyboardZ * keyboardSens;
        controller.Move(move * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        // TODO: movement based on local orientation


        // JUMPING
        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(height * -2f * gravity);
    }
}
