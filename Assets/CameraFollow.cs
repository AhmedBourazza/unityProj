using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform antTransform;  // The object to follow (the ant)
    public Vector3 offset = new Vector3(0, 2, -2); // Adjust values for a closer zoom
    public float followSpeed = 5f;  // Speed of the camera following the ant
    public float rotationSpeed = 5f;  // Speed of camera rotation to align with the ant

    void LateUpdate()
    {
        if (antTransform != null)
        {
            // Calculate the new camera position behind the ant
            Vector3 desiredPosition = antTransform.position + antTransform.TransformDirection(offset);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

            // Rotate the camera to stay behind the ant
            Quaternion targetRotation = Quaternion.LookRotation(antTransform.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
