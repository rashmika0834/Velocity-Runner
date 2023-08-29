using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the car's transform
    public Vector3 offset = new Vector3(-52, 41, 1); // Camera offset from the car
    public float smoothTime = 0.3f; // Smoothing time for camera movement

    private Vector3 velocity = Vector3.zero; // Velocity for SmoothDamp

    void Update()
    {
        if (target == null)
            return;

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;
        // Use SmoothDamp to smoothly move the camera towards the desired position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        // Look at the car
        transform.LookAt(target);
    }
}