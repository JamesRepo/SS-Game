using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * ==== Camera Control ====
 * ---------------
 * This class controls the camera. It allows the camera to be controlled 
 * by the player through touch controls. The player is able to orbit around
 * the grid. 
 * It also contains code to register mouse input. 
 * 
 */

public class CameraControl : MonoBehaviour {
    
    public Transform target;

    public float zoomDampening = 5.0f;

    /*
     * == Rotation / Position ==
     * Need to be stored seperately, position is
     * where it is. Rotation makes sure it is 
     * always looking at the play area.
     */
    // Stores the vector 3 position of the camera
    private Vector3 position;
    // Stores the rotation of the camera
    private Quaternion rotation;
    // Two more rotation variables for workings out. 
    // Current rotation will always equal transform.rotation but useful to have variable for ease of reading
    private Quaternion currentRotation;
    private Quaternion targetRotation;

    /*
     * These store the angle of degrees between the 
     * camera and play area. 
     */
    private float xAngle;
    private float yAngle;

    /*
     * Speed multiplyer applied to camera movements
     * 
     */
    private const float mouseMovementSpeed = 10f;
    private const float touchMovementSpeed = 0.25f;

    /*
     * Max angles of rotation for gameplay
     * 
     */
    private const int maxAngle = 80;
    private const int minAngle = 10;

    /*
     * Distance camera is from play grid
     * 
     */
    private const float cameraDistance = 20f;

    /*
     * Swipe Resistance
     * 
     */
    private const float swipeRes = 20f;
    private Vector2 touchStart;


    // Start used for initialisation 
    void Start() {
        // Initiliase position and rotation to the cameras starting position
        position = transform.position;
        rotation = transform.rotation;
        currentRotation = transform.rotation;
        targetRotation = transform.rotation;
        // Initialise angles of rotation
        xAngle = 0.0f;
        yAngle = 0.0f;

        // Store angles. Vector3 right is shorthand for Vector3(1, 0, 0). Up is for Vector3(0, 1, 0)
        xAngle = Vector3.Angle(Vector3.right, transform.right);
        yAngle = Vector3.Angle(Vector3.up, transform.up);

    }


    /* 
     * LateUpdate is called every frame but after all Update functions have. 
     * Use LateUpdate as its the camera so we need to track any object that might have moved during update.
     */
    void LateUpdate() {

        //// If Left Mouse Button is pressed
        //if (Input.GetMouseButton(0)) {
        //    // Register mouse axis movements and apply speed multiplyer. Save the change of angle in relevant variable 
        //    xAngle += Input.GetAxis("Mouse X") * mouseMovementSpeed;
        //    yAngle -= Input.GetAxis("Mouse Y") * mouseMovementSpeed;

        //    // Clamps the Y angle. Making sure the camera will not go over the top or underneath of the play area
        //    yAngle = ClampAngle(yAngle, minAngle, maxAngle);

        //    // Sets new rotation to rotate the degrees saved into the two variables
        //    targetRotation = Quaternion.Euler(yAngle, xAngle, 0);
        //    // Sets the current rotation to the current rotation of the camera
        //    currentRotation = transform.rotation;
        //    /*
        //     * Sets the rotation to a Lerp. With this you put in the starting rotation and the ending rotation and it
        //     * smoothly rotates from one angle to the next. So it doesn't just jut from one angle to another
        //     */
        //    rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * zoomDampening);
        //    // Sets the camera's rotation the Lerp, meaning it will smootly rotate
        //    transform.rotation = rotation;

        //    // Determines the position of the camera. Mostly used to keep it a certain distance
        //    position = target.position - (rotation * Vector3.forward * cameraDistance);
        //    transform.position = position;
        //}




        // If to register touches, looking for only one touch contact with screen. Also looking to see if the conact has moved
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            // Vector 2 to store the change in position since
            Vector2 touchposition = Input.GetTouch(0).deltaPosition;
            // Sets the angles and clamps within range
            xAngle += touchposition.x * touchMovementSpeed;
            yAngle -= touchposition.y * touchMovementSpeed;
            yAngle = ClampAngle(yAngle, minAngle, maxAngle);
            // Does rotation
            targetRotation = Quaternion.Euler(yAngle, xAngle, 0);
            currentRotation = transform.rotation;

            touchStart = Input.mousePosition;
            float swipeForce = touchposition.x - touchposition.y;

            rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;
            // Determines the position of the camera. Mostly used to keep it a certain distance
            position = target.position - (rotation * Vector3.forward * cameraDistance);
            transform.position = position;
        }
    }

    /*
     *  Used to make sure the clamp doesn't screw up.
     *  Not sure if actually need. Will check at some point. 
     * 
     */
    public float ClampAngle(float angle, float min, float max) {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}