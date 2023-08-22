using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 20f;
 
    public float edgeDistanceThreshold = 60f;
    public Transform player;

    public MoveTankScript moveTankScript;
    [SerializeField] private KeyCode moveButton = KeyCode.Space;

  //  public Transform playerTransform; // Reference to the player's transform
    private Vector3 previousPlayerPosition; // Previous position of the player
    private Vector2 previousMousePosition; // Previous position of the mouse
    private float distanceOld = 0;
    // Start is called before the first frame update
    void Start()
    {

        // Set the initial previous player position
        previousPlayerPosition = player.transform.position;

      


    }

    // Update is called once per frame
    void Update()
    {
       
      
        Vector2 mousePosition = Input.mousePosition;
        
        moveTankScript = player.GetComponent<MoveTankScript>();
       
      
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Bounds playerBounds = player.GetComponent<Renderer>().bounds;
        Vector2 cameraPosition = Camera.main.transform.position;
        float leftEdge = cameraPosition.x - cameraWidth / 2f;
        float rightEdge = cameraPosition.x + cameraWidth / 2f;
        float bottomEdge = cameraPosition.y - cameraHeight / 2f;
        float topEdge = cameraPosition.y + cameraHeight / 2f;
        float actualMovementSpeed = movementSpeed;
        
        //  Vector2 playerposition = player.transform.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");





        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPos.z = transform.position.z; // Keep the z-coordinate unchanged

        var distance = Vector2.Distance(new Vector2(mouseWorldPos.x, mouseWorldPos.y), new Vector2(player.position.x, player.position.y));
        Vector2 direction = new Vector2(mouseWorldPos.x, mouseWorldPos.y) - new Vector2(player.transform.position.x, player.transform.position.y);
        direction.Normalize();

        float maxDistance = 8.0f; // Maximum distance from the player that the camera can move

        if (distance > maxDistance && mousePosition != previousMousePosition)
        {
            Vector3 targetPosition = player.transform.position + (Vector3)direction * maxDistance;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPosition, 3 * Time.deltaTime);
         } else if (distance < maxDistance && mousePosition != previousMousePosition)
        {
            // Vector2 targetPosition = mouseWorldPos.transform.position;
            mouseWorldPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, mouseWorldPos, 3 * Time.deltaTime);
        }

        //if (distance < distanceOld && mousePosition != previousMousePosition && distance < 9)
        //{
        //    Debug.Log("In the if loop");w
        //    Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        //    transform.position = Vector3.Lerp(transform.position, targetPosition, 1 * Time.deltaTime);

        //}

        previousMousePosition = mousePosition;
        distanceOld = distance;


        
           

            //Debug.Log(mousePosition.x + "<new old>" + distanceOld);

        //// Move camera if the mouse is near the screen edges
        //if (mousePosition.x < edgeDistanceThreshold)
        //{
        //    if (playerBounds.max.x < rightEdge)
        //    {
        //        transform.Translate(Vector2.left * actualMovementSpeed * Time.deltaTime);
        //    }
        //}
        //else if (mousePosition.x > Screen.width - edgeDistanceThreshold)
        //{
        //    if (playerBounds.min.x > leftEdge)
        //    {
        //        transform.Translate(Vector2.right * actualMovementSpeed * Time.deltaTime);
        //    }
        //}

        //if (mousePosition.y < edgeDistanceThreshold)
        //{
        //    if (playerBounds.max.y < topEdge)
        //    {
        //        transform.Translate(Vector2.down * actualMovementSpeed * Time.deltaTime);
        //    }
        //}
        //else if (mousePosition.y > Screen.height - edgeDistanceThreshold)
        //{
        //    if (playerBounds.min.y > bottomEdge)
        //    {
        //        transform.Translate(Vector2.up * actualMovementSpeed * Time.deltaTime);
        //    }
        //}






        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Calculate the player's movement direction
            Vector3 playerMovement = player.transform.position - previousPlayerPosition;

            // Calculate the target position for the camera
            Vector3 targetPosition = transform.position + playerMovement;

            // Update the camera's position towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, (moveTankScript.speed *20) * Time.deltaTime);

            // Update the previous player position
            previousPlayerPosition = player.transform.position;

   
        }

       


        //// Move camera if mouse is near the screen edges
        //if (mousePosition.x < edgeDistanceThreshold)
        //{
        //    if (playerBounds.max.x < rightEdge)
        //    {

        //     transform.Translate(Vector2.left * actualMovementSpeed * Time.deltaTime);
        //    } 
           
        //}
        //else if (mousePosition.x > Screen.width - edgeDistanceThreshold )
        //{
        //    if (playerBounds.min.x > leftEdge)
        //    {

        //     transform.Translate(Vector2.right * actualMovementSpeed * Time.deltaTime);
        //    }
          
        //}

        //if (mousePosition.y < edgeDistanceThreshold)
        //{
        //    if (playerBounds.max.y < topEdge)
        //    {
        //        transform.Translate(Vector2.down * actualMovementSpeed * Time.deltaTime);
        //    }
        //}
        //else if (mousePosition.y > Screen.height - edgeDistanceThreshold)
        //{
        //    if (playerBounds.min.y > bottomEdge)
        //    {
        //        transform.Translate(Vector2.up * actualMovementSpeed * Time.deltaTime);
                
        //    }
        //}




        //var mouseWorldPos =  Camera.main.ScreenToWorldPoint(mousePosition);
        //var distance = Vector3.Distance(mouseWorldPos, player.position);


        //// Calculate the direction from the player position to the mouse position
        //Vector2 direction = mouseWorldPos - player.position;
        //direction.Normalize();

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        ////distance calculate



        //if (distance < distanceOld && distance > 1)
        //{

        //    if (angle >= 0 && angle <= 180)
        //    {

        //        transform.Translate(Vector2.down * actualMovementSpeed * Time.deltaTime);
        //    }

        //}



        //distanceOld = distance;








    }
       // Debug.Log("X: "+ mousePosition.x +" Y: "+ mousePosition.y + " ScreenWidth "+ Screen.width);
       
    
}
