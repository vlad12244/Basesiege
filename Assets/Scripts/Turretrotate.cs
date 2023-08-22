using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turretrotate : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 1f;
    [SerializeField] private float angleOffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space
        Vector2 mousePosition = Input.mousePosition;

        // Convert the mouse position to world space
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the turret position to the mouse position
        Vector2 direction = worldMousePosition - (Vector2)transform.position;
        direction.Normalize();

        // Calculate the angle in degrees between the turret's forward direction and the mouse direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the offset angle
        angle += angleOffset;

        // Rotate the turret towards the adjusted angle with the defined rotation speed
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
