using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField] private float sensitivity = 5f; // How sensitive the camera rotation is
    [SerializeField] private float minYAngle = -60f; // Minimum vertical angle for camera rotation
    [SerializeField] private float maxYAngle = 60f; // Maximum vertical angle for camera rotation
    [Header("Assignments")]
    [SerializeField] private Transform player; // The player to follow (usually the head)

    private float currentX = 0f;
    private float currentY = 0f;

    private void Start()
    {
        // Initialize the rotation of the camera
        currentX = transform.eulerAngles.y;
        currentY = transform.eulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;  // Locks the cursor to the center of the screen
        Cursor.visible = false; // Hides the cursor
    }

    private void LateUpdate()
    {
        // Mouse input for camera rotation
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp the vertical angle to prevent excessive up/down rotation
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        // Apply rotation to the camera
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Set camera's position to the player's head (or desired location)
        transform.position = player.position + Vector3.up * 1.5f; // Adjust height as needed

        // Apply the rotation to the camera
        transform.rotation = rotation;
    }
}