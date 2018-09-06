using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
     * 
     */

    // Fall counts the amount of seconds till next drop.
    private float fall;
    // Counter to slowly increase speed as the game goes on. Static so it does not reset every time there is a new shape.
    public static float fallSpeed = 3;

    /*
     * 
     * ==== Unity Functions ====
     * 
     */

    // Start used to initialise the fall time counter and speed. Also repeatedly invokes the speed up method.
    void Start() {
        fall = 0;
        InvokeRepeating("IncreaseSpeed", 2.0f, 4.0f);
	}
    // Update checks the drop timer method every frame.
    void Update() {
        DropTimer();
    }

    /*
     * 
     * ==== Methods ====
     *
     */

    /* 
     * Drop timer is the method that keeps track of the time and if the 
     * shape needs to drop a position on the Y-Axis. 
     */
    public void DropTimer() {
        if (Time.timeSinceLevelLoad - fall >= fallSpeed) {
            fall = Time.timeSinceLevelLoad;
            Drop();
        }
    }

    /*
     * Checks if a new shape needs to be created.
     */
    public void NewShape() {
        enabled = false;
        FindObjectOfType<ShapeCreator>().CreateShape();
    }

    /*
     * Checks if the shape is within the grid and the position it wants to move to is available.
     * Cycles through every cell in the shape to do this and so checks if the position is taken,
     * and then if the position is taken by it's parent shape. 
     */
    public bool CheckShape() {
        // Cycles through the individual cell's postions, checking if they are in the grid.
        foreach(Transform cell in transform) {
            Vector3 vPos = Grid.RoundPosition(cell.position);
            if(!Grid.CheckGridLimits(vPos)) {
                return false;
            }
            // First checks if the position is taken, then if it is taken by its parent.
            if(Grid.gameArea[(int)vPos.x, (int)vPos.y, (int)vPos.z] != null && Grid.gameArea[(int)vPos.x, (int)vPos.y, (int)vPos.z].parent != transform) {
                return false;
            }
        }
        return true;
    }

    /*
     * Updates the grid with a shape's new position by cycling through its cells again. 
     */
    public void UpdateGrid() {
        FindObjectOfType<Grid>().UpdateGrid(this);
    }

    /*
     * Gradually increases the speed at which the shapes fall. 
     */
    public void IncreaseSpeed() {
        fallSpeed -= 0.001f;
    }

    /*
     * 
     * ---- Drop / Instansiation ----
     * 
     */

    /*
     * Called when a shape has reached the bottom or landed on another shape. 
     * It increments the score, checks if rows can be deleted, checks if 
     * the shapes have reached the top of the grid and it is game over, and 
     * creates a new shape. 
     */
    public void SuccessDrop() {
        FindObjectOfType<Scoring>().LandScore();
        Grid.DeleteFullRows();
        if (FindObjectOfType<Grid>().CheckGameOver(this)) {
            FindObjectOfType<UISystem>().PauseGameOver(true);
        }
        NewShape();
    }

    /*
     * Drop called when a shape drops automatically due to the timer.
     */
    public void Drop() {
        transform.position += new Vector3(0, -1, 0);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.position += new Vector3(0, 1, 0);
            SuccessDrop();
        }
    }

    /*
     * Drop Shape is called if the user decides to drop a shape to the 
     * bottom. 
     * Uses a for loop. 
     */
    public void DropShape() {
        for (int a = (int)transform.position.y; a > 0; --a) {
            transform.position += new Vector3(0, -1, 0);
            if (CheckShape()) {
                UpdateGrid();
            }
            else {
                transform.position += new Vector3(0, 1, 0);
                SuccessDrop();
                break;
            }
            if ((int)transform.position.y == 0) {
                SuccessDrop();
                break;
            }
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
        transform.Rotate(Vector3.left, 90, Space.World);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.Rotate(Vector3.left, -90, Space.World);
        }
    }
    public void RotateY() {
        transform.Rotate(Vector3.up, -90, Space.World);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.Rotate(Vector3.up, 90, Space.World);
        }
    }
    public void RotateZ() {
        transform.Rotate(Vector3.forward, 90, Space.World);
        if (CheckShape()) {
            UpdateGrid();
        }
        else {
            transform.Rotate(Vector3.forward, -90, Space.World);
        }
    }
}