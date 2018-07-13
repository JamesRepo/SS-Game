using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private float fall = 0;
    public float fallSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CheckuserInput();
        CheckForNew();
	}

    /* 
     * Method used to detect User input and perform the relevant action.
     * These relevant actions are to move the block or rotate it. 
     * These actions are performed on the downward press of a key by the user. 
     */
    void CheckuserInput() {
        // Right arrow pressed - block moves +1 on the X axis
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        // Left arrow is pressed - block moves -1 on the X axis
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        // Down arrow is pressed - block moves +1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, 1);
        }
        // Up arrow is pressed - block moves -1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, -1);
        }
        // Space key is pressed - block moves -1 on the Y axis
        // This statement also includes a timer to make the block fall without user input
        else if (Input.GetKeyDown(KeyCode.Space) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.Q)) {
            transform.Rotate(0, 90, 0);
        }
    }

    void CheckForNew() {
        if ((int)transform.position.y == 0) {
            enabled = false;
            FindObjectOfType<Game>().SpawnNewCube();
        }
    }

    //bool CheckIsValid() {

    //    foreach(Transform mino in transform) {
    //        Vector3 pos = FindObjectOfType<Game>().Round(mino.position);

    //        if(FindObjectOfType<Game>().CheckInGrid(pos) == false) {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
}
