using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_Character_Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 180.0f;

    private CharacterController controller;
    private Animator animator;

    private Camera mainCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, transform.position.z);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float moveSpeed = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);

        controller.Move(transform.TransformDirection(new Vector3(horizontalInput, 0.0f, verticalInput)) * speed * moveSpeed * Time.deltaTime);

        if (horizontalInput != 0)
        {
            float rotationAmount = horizontalInput * turnSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }

        animator.SetFloat("MovementSpeed", moveSpeed);
    }
}
