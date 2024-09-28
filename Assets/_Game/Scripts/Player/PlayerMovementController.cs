using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private float speed = 5f; // Speed of the player movement
    [SerializeField] private float gravity = -9.81f; // Gravity force to apply
    [SerializeField] private float groundDistance = 0.4f; // Distance to check if the player is grounded

    [Header("Assignments")] 
    [SerializeField] private CharacterController controller; // Reference to the CharacterController component
    [SerializeField] private LayerMask groundMask; // Layer to define what is ground
    [SerializeField] private Transform groundCheck; // Position to check for the ground
    [SerializeField] private Transform cameraTransform; // Reference to the camera's transform

    private float rotationSpeed = 700f; // Speed of the player's rotation
    private Vector3 velocity; // Velocity for gravity calculation
    private bool isGrounded; // Flag to check if the player is grounded

    void Update()
    {
        CheckGround();

        MovePlayer();

        ApplyGravity();
    }

    private void CheckGround()
    {
        // Ground detection
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void MovePlayer()
    {
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
    }

    private void ApplyGravity()
    {
        // Add downward force to the player's velocity if the player is not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity);
        }
    }
}