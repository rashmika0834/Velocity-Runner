using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the car's transform
    public float distance = 47f; // Distance from the car
    public float height = 26f; // Height above the car
    public float rotationDamping = 2f; // Damping for camera rotation

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired rotation angle based on the car's rotation
        float desiredRotationAngle = target.eulerAngles.y;
        float desiredHeight = target.position.y + height;

        // Calculate the current rotation angle and height using Mathf.Lerp for smoothing
        float currentRotationAngle = Mathf.LerpAngle(transform.eulerAngles.y, desiredRotationAngle, rotationDamping * Time.deltaTime);
        float currentHeight = Mathf.Lerp(transform.position.y, desiredHeight, rotationDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera behind the car based on the desired distance and height
        Vector3 newPosition = target.position - currentRotation * Vector3.forward * distance;
        newPosition.y = currentHeight;

        // Set the position and rotation of the camera
        transform.position = newPosition;
        transform.LookAt(target.position);
    }
}
