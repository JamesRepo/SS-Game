using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour {
    private float fall = 0;
    public float fallSpeed = 1;

    private const int gridHeight = 10;
    private const int gridWidth = 5;

    private Vector3 position;

    public Cell[] shapeCells = new Cell[4];

    public Button left, right, up, down;

    //  private Button rightButton = GameObject.Find("buttonName").GetComponent<UnityEngine.UI.Button>();


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        CheckuserInput();
    }
    /* 
     * Method used to detect User input and perform the relevant action.
     * These relevant actions are to move the block or rotate it. 
     * These actions are performed on the downward press of a key by the user. 
     */
    void CheckuserInput() {
        // Right arrow pressed - block moves +1 on the X axis
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(1, 0, 0);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.position += new Vector3(-1, 0, 0);
            }
        }


        // Left arrow is pressed - block moves -1 on the X axis
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1, 0, 0);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.position += new Vector3(1, 0, 0);
            }
        }


        // Down arrow is pressed - block moves +1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, 0, -1);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.position += new Vector3(0, 0, 1);
            }
        }


        // Up arrow is pressed - block moves -1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, 0, 1);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.position += new Vector3(0, 0, -1);
            }
        }


        // Space key is pressed - block moves -1 on the Y axis
        // This statement also includes a timer to make the block fall without user input
        else if (Input.GetKeyDown(KeyCode.Space) || Time.time - fall >= fallSpeed) {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                Debug.Log("Posx:" + transform.position.x + ", Posy:" + transform.position.y + ", Posz:" + transform.position.z);
                transform.position += new Vector3(0, 1, 0);
                Grid.DeleteFullRows();
               // Grid.DeleteFullX();
               // Grid.DeleteFullZ();
                NewShape();
            }
        }


        // Rotation 
        else if (Input.GetKeyDown(KeyCode.Q)) {
            transform.Rotate(0, 90, 0);
            if (CheckShape()){
                UpdateGrid();
            }
            else {
                transform.Rotate(0, -90, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            transform.Rotate(90, 0, 0);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.Rotate(-90, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            transform.Rotate(0, 0, 90);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.Rotate(0, 0, -90);
            }
        }
    }



    // Checks if a new shape can be instansiated
    void NewShape() {
        // cast as an integer as the position is a float by default
       // if ((int)transform.position.y == 0) {
            enabled = false;
            FindObjectOfType<Game>().SpawnNewCube();
      //  }
    }
    // Checks if the shape is in the grid and whether the position it wants to move to is available
    public bool CheckShape() {
        // cycles through the individual cell's postions, checking if they are in the grid
        foreach(Transform cell in transform) {
            Vector3 vPos = Grid.RoundPosition(cell.position);
            if(!Grid.CheckGridLimits(vPos)) {
                return false;
            }
            // First checks if the position is taken, then if it is taken by its parent 
            if(Grid.gameArea[(int)vPos.x, (int)vPos.y, (int)vPos.z] != null && Grid.gameArea[(int)vPos.x, (int)vPos.y, (int)vPos.z].parent != transform) {
                return false;
            }
        }
        return true;
    }

    // Updates the game board
    public void UpdateGrid() {
        for (int x = 0; x < gridWidth; ++x) {
            for (int y = 0; y < gridHeight; ++y) {
                for (int z = 0; z < gridWidth; ++z) {
                    
                    if (Grid.gameArea[x, y, z] != null && Grid.gameArea[x, y, z].parent == transform) {
                        Grid.gameArea[x, y, z] = null;
                    }
                }
            }
        }
        foreach (Transform cell in transform) {
            Vector3 vPos = Grid.RoundPosition(cell.position);
            Grid.gameArea[(int)vPos.x, (int)vPos.y, (int)vPos.z] = cell;
         //   Debug.Log("Cube at:" + vPos.x + " " + vPos.y + " " + vPos.z);
        }
    }

 



}
