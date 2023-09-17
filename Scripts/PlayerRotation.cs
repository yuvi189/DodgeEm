using UnityEngine;

public class RotateBall : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the rotation speed as needed.
    public Vector3 rotationAxis = Vector3.up; // Set the desired rotation axis.

    private void Update()
    {
        // Rotate the parent sphere (which includes the golf ball model) around the specified axis.
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
