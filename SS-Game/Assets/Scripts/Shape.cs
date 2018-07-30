using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ==== Shape ====
 * ---------------
 * This class is attached to the shapes which are used in the game.
 * It contains methods to control the movement and rotation of the shape, 
 * as well as methods which check the shape is in the game area and update 
 * the three-dimensional array with the shape's position.
 * 
 */

public class Shape : MonoBehaviour {

    /*
     *
     * ==== Variables ====
     * 
     */

    private float fall = 0;
    private float fallSpeed = 1;
    private const int gridHeight = 15;
    private const int gridWidth = 5;
    private Vector3 vectorPosition;

    /*
     * 
     * ==== Constructor ====
     * 
     */

    public Shape() {}

    /*
     * 
     * ==== Unity Functions ====
     * 
     */

    void Start () {
		
	}
    void Update() {
        CheckUserInput();
    }

    /*
     * 
     * ==== Methods ====
     *
     */


    /* 
     * Method used to detect User input and perform the relevant action.
     * These relevant actions are to move the block or rotate it. 
     * These actions are performed on the downward press of a key by the user. 
     */
    void CheckUserInput() {
        // Right arrow pressed - block moves +1 on the X axis
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveRight();
        }


        // Left arrow is pressed - block moves -1 on the X axis
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveLeft();
        }


        // Down arrow is pressed - block moves +1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            MoveDown();
        }


        // Up arrow is pressed - block moves -1 on the Z axis
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            MoveUp();
        }


        // Space key is pressed - block moves -1 on the Y axis
        // This statement also includes a timer to make the block fall without user input
        else if (Input.GetKeyDown(KeyCode.Space) || Time.time - fall >= fallSpeed) {
            fall = Time.time;
            Drop();
        }


        // Rotation 
        else if (Input.GetKeyDown(KeyCode.Q)) {
            RotateX();
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            RotateY();
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            RotateZ();
        }
    }





    // Checks if a new shape can be instansiated
    public void NewShape() {
        enabled = false;
        FindObjectOfType<ShapeCreator>().CreateShape();
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
        }
    }






    public Vector3 GetVecPosition() {
        vectorPosition = transform.position;
        return vectorPosition;
    }

















    /*
     * 
     * ---- Drop / Instansiation ----
     * 
     */

    public void Drop() {
        transform.position += new Vector3(0, -1, 0);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.position += new Vector3(0, 1, 0);
            Grid.DeleteFullRows();
            // Grid.DeleteFullX();
            // Grid.DeleteFullZ();
            NewShape();
        }
    }

    /*
     * 
     *  ---- Movement ----
     * 
     */

    public void MoveLeft() {
        transform.position += new Vector3(-1, 0, 0);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    public void MoveRight() {
        transform.position += new Vector3(1, 0, 0);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    public void MoveUp() {
        transform.position += new Vector3(0, 0, 1);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.position += new Vector3(0, 0, -1);
        }
    }

    public void MoveDown() {
        transform.position += new Vector3(0, 0, -1);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.position += new Vector3(0, 0, 1);
        }
    }

    /*
     * 
     *  ---- Rotation ----
     * 
     */

    public void RotateX() {
        transform.Rotate(-90, 0, 0);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.Rotate(90, 0, 0);
        }
    }

    public void RotateY() {
        transform.Rotate(0, 90, 0);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.Rotate(0, -90, 0);
        }
    }

    public void RotateZ() {
        transform.Rotate(0, 0, 90);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.Rotate(0, 0, -90);
        }
    }


}