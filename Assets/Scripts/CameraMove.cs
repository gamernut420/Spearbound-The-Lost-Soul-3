using UnityEngine;

public class CameraMove : MonoBehaviour
{  public Transform player; // Assign your player GameObject in the Inspector
    public Vector3 offset; // Adjust this in the Inspector to set the camera's relative position
    public float smoothSpeed = 0.125f; // Controls the smoothness of the camera movement

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform not assigned to CameraFollow2D script.");
            return;
        }

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
