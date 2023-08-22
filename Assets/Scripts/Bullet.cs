using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int maxRicochetCount = 6;
    public LayerMask collisionMask;
    public Collider2D Tank;
    private Rigidbody2D rb;
    private int ricochetCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false; // Set the Rigidbody2D to not be kinematic for physics interactions
    }

    public void Initialize(Vector2 direction)
    {
        Debug.Log("initialized");
        // Set the initial direction and speed of the bullet
        rb.velocity = direction.normalized * speed;

        // Calculate the rotation angle to face the new direction
        float rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the bullet
        transform.eulerAngles = new Vector3(0f, 0f, rotationAngle - 90f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider == Tank)
        {
            Destroy(gameObject); // Set the bullet's mass to 0 when colliding with the tank
        }
        else
        // Check if the bullet should ricochet
        if (ricochetCount < maxRicochetCount)
        {
            Vector2 newDirection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            ricochetCount++;

            // Calculate the new rotation angle to face the new direction after the bounce
            float rotationAngle = 90- Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg + 180;

            // Apply the rotation to the bullet
            transform.eulerAngles = new Vector3(0f, 0f, rotationAngle); // Add 90 degrees to the rotation angle

            // Update the velocity with the new direction
            rb.velocity = newDirection.normalized * speed;
        }
        else
        {
            Destroy(gameObject); // Destroy the bullet after reaching the maximum ricochet count
        }
    }
}