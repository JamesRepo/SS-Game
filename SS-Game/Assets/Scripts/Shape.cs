using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    private float fall = 0;
    public float fallSpeed = 1;

    private Vector3 position;

    public Cell[] shapeCells = new Cell[4];


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        CheckuserInput();
        CheckForNew();
     //   GetCellPositions();
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
            if (CheckPositionValid()) {
                UpdateGrid();
            }
            else {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        // Left arrow is pressed - block moves -1 on the X axis
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
          //  FindObjectOfType<Grid>().GridUpdate(this);
            if (CheckPositionValid())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        // Down arrow is pressed - block moves +1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1);
           // FindObjectOfType<Grid>().GridUpdate(this);
            if (CheckPositionValid())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 0, 1);
            }
        }
        // Up arrow is pressed - block moves -1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1);
           // FindObjectOfType<Grid>().GridUpdate(this);
            if (CheckPositionValid())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 0, -1);
            }
        }
        // Space key is pressed - block moves -1 on the Y axis
        // This statement also includes a timer to make the block fall without user input
        else if (Input.GetKeyDown(KeyCode.Space) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
          //  FindObjectOfType<Grid>().GridUpdate(this);
        }
        // Rotation 
        else if (Input.GetKeyDown(KeyCode.Q)) 
        {
            transform.Rotate(0, 90, 0);
            if (CheckPositionValid())
            {
                UpdateGrid();
            }
            else
            {
                transform.Rotate(0, -90, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(90, 0, 0);
            if (CheckPositionValid())
            {
                UpdateGrid();
            }
            else
            {
                transform.Rotate(-90, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 0, 90);
            if (CheckPositionValid())
            {
                UpdateGrid();
            }
            else
            {
                transform.Rotate(0, 0, -90);
            }
        }
    }

    void CheckForNew() {
        // cast as an integer as the position is a float by default
        if ((int)transform.position.y == 0) {
            enabled = false;
            FindObjectOfType<Game>().SpawnNewCube();
        }
    }

    //public Vector3 GetPosition() {
    //    return position;
    //}

    //public void GetCellPositions() {
    //    for (int i = 0; i < shapeCells.Length; i++) {
    //        Debug.Log(shapeCells[i].transform);
    //    }
    //}

    //public void OnCollisionEnter()
    //{
    //    enabled = false;
    //    FindObjectOfType<Game>().SpawnNewCube();
    //}

    //public Vector3 GetShapePosition() {
    //    Vector3[] positions = new Vector3[shapeCells.Length];

    //    for (int a = 0; a < shapeCells.Length; a++) {
    //        positions[a] = new Vector3(shapeCells[a].getPositionX, shapeCells[a].getPositionY, shapeCells[a].getPositionZ);
    //    }

    //    return positions;
    //}

    //public void GetCellPositions(Cell cell) {

    //}

    //bool CheckIsValid() {

    //    foreach(Transform mino in transform) {
    //        Vector3 pos = FindObjectOfType<Game>().Round(mino.position);

    //        if(FindObjectOfType<Game>().CheckInGrid(pos) == false) {
    //            return false;
    //        }
    //    }
    //    return true;
    //}


    // Find the individual cells positions and find out if it is within the grid when trying to move
    public bool CheckPositionValid() {
        foreach (Transform cell in transform) {
            Vector3 pos = Grid.RoundPosition(cell.position);
            if (!Grid.CheckShapeInGrid(pos)) {
                return false;
            }
            if (Grid.gameArea[(int)pos.x, (int)pos.y, (int)pos.z] != null && Grid.gameArea[(int)pos.x, (int)pos.y, (int)pos.z].parent != transform) {
                return false;
            }
        }
        return true;
    }

    // Method to update the grid
    public void UpdateGrid() {
        for (int y = 0; y < 10; ++y) {
            for (int x = 0; x < 10; ++x) {
                for (int z = 0; z < 10; ++z) {
                    if (Grid.gameArea[x, y, z] != null) {
                        if (Grid.gameArea[x, y, z].parent == transform) {
                            Grid.gameArea[x, y, z] = null;
                        }
                    }
                }
            }
        }
        foreach (Transform cell in transform) {
            Vector3 pos = Grid.RoundPosition(cell.position);
            Grid.gameArea[(int)pos.x, (int)pos.y, (int)pos.z] = cell;
        }

    }
}
