using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour {
    
    public Transform centrePoint;

    private Vector3 startPoint, endPoint;

    private Vector3 offset;

    private Vector2 start;

    private float distance = 5.0f;

    private float yOffset = 14.5f;

    private float zOffset = -0.3f;

    private float swipeRes = 100f;

    private float xAngle, yAngle;

    private const float rotationSpeed = 5f;

    public CameraControl() {
        startPoint = new Vector3(0, 0, 0);
        endPoint = new Vector3(0, 0, 0);
        xAngle = 0.0f;
        yAngle = 0.0f;
    }

    private void Start() {
        offset = new Vector3(0, yOffset, -1f * distance);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            MoveCamera(true);
        }
        else if (Input.GetKeyDown(KeyCode.V)) {
            MoveCamera(false);
        }
        CameraUpdate();
        transform.position = centrePoint.position + offset;
        transform.LookAt(centrePoint);
    }


    // direction = true for left -- direction = false for right
    public void MoveCamera(bool direction) {
        if (direction == true) {
            offset = Quaternion.Euler(0, 90, 0) * offset;
        }
        if (direction == false) {
            offset = Quaternion.Euler(0, -90, 0) * offset;
        }
    }


    public void CameraUpdate() {
        
        if (Input.GetMouseButtonDown(0)) {
            start = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
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

}
