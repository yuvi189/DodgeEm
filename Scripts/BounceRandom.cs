using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;
    private Vector3 randomDirection;

    public float moveSpeed = 5.0f;
    public float bounceForce = 10.0f; // Adjust the bounce force as needed.
    public float directionChangeInterval = 2.0f; // Time between direction changes.

    private float timeSinceLastDirectionChange = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;

        // Initialize a random direction.
        randomDirection = Random.insideUnitSphere.normalized;

        // Apply the initial velocity in that direction.
        rb.velocity = randomDirection * moveSpeed;
    }

    void Update()
    {
        timeSinceLastDirectionChange += Time.deltaTime;

        // Check if it's time to change direction.
        if (timeSinceLastDirectionChange >= directionChangeInterval)
        {
            // Randomize the direction and apply it as a new velocity.
            randomDirection = Random.insideUnitSphere.normalized;
            rb.velocity = randomDirection * moveSpeed;

            // Reset the timer.
            timeSinceLastDirectionChange = 0.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Calculate the reflection direction.
            Vector3 reflection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflection * bounceForce;
        }
    }
}
