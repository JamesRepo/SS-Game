using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CameraMovementCheck();
	}

    public void CameraMovementCheck() {

        if (Input.GetKeyDown(KeyCode.A)) {
            transform.position = new Vector3(10, 12, 2);
            transform.Rotate(45, -90, 0);
        }
    }
}
