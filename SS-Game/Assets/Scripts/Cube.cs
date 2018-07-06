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

    void CheckuserInput() {

        if(Input.GetKeyDown(KeyCode.RightArrow)) {

            transform.position += new Vector3(1, 0, 0);
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, 1);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Time.time - fall >= fallSpeed) 
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
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
