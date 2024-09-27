using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player; // The player to follow
    [SerializeField] public Vector3 offset; // Offset of the camera from the player
    public float sensitivity = 5f; // How sensitive the camera rotation is
    public float distance = 5f; // Default distance from the player
    public float minYAngle = -30f; // Minimum angle for camera rotation
    public float maxYAngle = 60f; // Maximum angle for camera rotation
    public LayerMask collisionLayers; // Layers to detect for collisions

    private float currentX = 0f;
    private float currentY = 0f;

    private void Start()
    {
        // Initialize camera offset and angles
        offset = new Vector3(0, 1.5f, -distance); // Adjust offset as needed
        currentX = transform.eulerAngles.y;
        currentY = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        // Mouse input for camera rotation
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp the vertical angle
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        // Calculate camera direction and rotation
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        // Check for obstacles with raycasting to prevent clipping
        RaycastHit hit;
        if (Physics.Raycast(player.position, desiredPosition - player.position, out hit, distance, collisionLayers))
        {
            // Move camera closer if hitting an obstacle
            transform.position = hit.point;
        }
        else
        {
            // Set the camera's position normally
            transform.position = desiredPosition;
        }

        // Always look at the player
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}