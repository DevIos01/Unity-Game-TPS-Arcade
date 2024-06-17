using UnityEngine;

public class TPS_Character_Controller : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float turnSpeed = 200.0f;

    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Calculate the movement speed and direction
        float speed = isRunning ? runSpeed : walkSpeed;
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * speed * Time.deltaTime;

        // Rotate the character based on horizontal input
        transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);

        // Move the character
        rb.MovePosition(rb.position + transform.TransformDirection(movement));

        // Update animation parameters
        HandleAnimations(movement, horizontal, isRunning);
    }

    private void HandleAnimations(Vector3 movement, float horizontal, bool isRunning)
    {
        // Determine whether the character is walking or running
        bool isWalking = movement.magnitude > 0 && !isRunning;

        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsRunning", isRunning);
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetFloat("Turn", horizontal);
    }
}