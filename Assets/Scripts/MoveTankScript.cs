using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTankScript : MonoBehaviour
{
    public float speed = 2;
    public float rotationSpeed = 50.0f; // Set the desired rotation speed value
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0, verticalInput).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }
}
