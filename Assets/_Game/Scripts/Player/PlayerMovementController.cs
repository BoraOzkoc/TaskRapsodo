using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;  // Reference to the CharacterController component
    public float speed = 5f;                // Speed of the player movement
    public float rotationSpeed = 700f;      // Speed of the player's rotation
    public Transform cameraTransform;       // Reference to the camera's transform
    public float gravity = -9.81f;          // Gravity force to apply
    public float groundDistance = 0.4f;     // Distance to check if the player is grounded
    public LayerMask groundMask;            // Layer to define what is ground
    public float jumpHeight = 1.5f;         // How high the player can jump

    private Vector3 velocity;               // Velocity for gravity calculation
    private bool isGrounded;                // Flag to check if the player is grounded
    public Transform groundCheck;           // Position to check for the ground

    void Update()
    {
        // Ground detection
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If the player is grounded and not falling, reset vertical velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small negative value to keep the player grounded
        }

        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Only move and rotate if there is input
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on camera's forward direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Smoothly rotate the player towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Calculate the move direction relative to the camera
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // Move the player according to the camera's forward direction
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
