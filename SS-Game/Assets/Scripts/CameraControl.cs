using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour {
    
    // This will be the play area, used as the focus for the camera
    public Transform centrePoint;

    // Offset from the centre point, the angel etc
    private Vector3 offset;

    // The distance the offset is from the play area
    private float distance = 5.0f;

    // The height at which the camera is offset from the play area 
    private float yOffset = 12.5f;

    // Vector position to record the mouse down position 
    private Vector2 start;

    // Swipe resistant, so the player must swipe more than this much on screen for the swipe to be registered 
    private float swipeRes = 100f;

    private float rotateSpeed = 5f;



    // ==== Not currently used ====
    // private Vector3 startPoint, endPoint;
    // private float xAngle, yAngle;
    // private float zOffset = -0.3f;
    // private const float rotationSpeed = 5f;

    // Constructor - not needed really
    public CameraControl() {
        //startPoint = new Vector3(0, 0, 0);
        //endPoint = new Vector3(0, 0, 0);
        //xAngle = 0.0f;
        //yAngle = 0.0f;
    }


    // Initialise the offset
    private void Start() {
        offset = new Vector3(0, yOffset, -1f * distance);
    }

    // Checks for user input
    private void Update() {
        //// Keyboard controls 
        //if (Input.GetKeyDown(KeyCode.C)) {
        //    MoveCamera(true);
        //}
        //else if (Input.GetKeyDown(KeyCode.V)) {
        //    MoveCamera(false);
        //}

        //// Calls a method to check for touches
        //CameraUpdate();
        //// Moves the camera to the point of offset
        //transform.position = centrePoint.position + offset;


       // NewThing();
        // Makes sure the camera is looking at the centre point
       // transform.LookAt(centrePoint);
    }

    // direction = true for left -- direction = false for right
    public void MoveCamera(bool direction) {
        // Changes the offset angle to + 90 degrees
        if (direction == true) {
            offset = Quaternion.Euler(0, 90, 0) * offset;
        }
        // - 90 degrees
        if (direction == false) {
            offset = Quaternion.Euler(0, -90, 0) * offset;
        }
    }

    // method to handle input from touch screen .. ==== .. 
    public void CameraUpdate() {
        // Mouse click or touch 
        if (Input.GetMouseButtonDown(0)) {
            // Sets the vector2 position to the touch 
            start = Input.mousePosition;
        }
        // When mouse is released
        if (Input.GetMouseButtonUp(0)) {
            // If the swipe is long enough it will do the thing
            float swipeForce = start.x - Input.mousePosition.x;
            if (Mathf.Abs(swipeForce) > swipeRes) {
                if (swipeForce < 0) {
                    MoveCamera(true);
                }
                else {
                    MoveCamera(false);
                }
            }
        }
    }



    public void NewThing() {
        transform.RotateAround(new Vector3(4.5f, 0f, 4.5f), new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * rotateSpeed);
    }
}