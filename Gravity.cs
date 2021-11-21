using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 velocity;
    
    float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Gravity going on...");
    }

    // Update is called once per frame
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
