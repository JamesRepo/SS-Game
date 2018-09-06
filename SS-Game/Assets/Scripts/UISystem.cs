using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * ==== UI System ====
 * -------------------
 * This class handles all of the buttons and controls that are on the UI.
 * These are the controls that do not move with the camera and are placed 
 * on the relative canvases in the Unity editor. 
 * 
 */

public class UISystem : MonoBehaviour {

    /*
     *
     * ==== Variables ====
     *  
     * 
     */

    public static bool isGamePaused;
    public Canvas gameCanvas, pauseCanvas, gameOverCanvas;

    /*
     * 
     * ==== Unity Functions ====
     * 
     */

    void Start()
    {
        isGamePaused = false;
    }

    /*
     * 
     * ==== Methods ====
     *
     */

    /*
     * This method gets an argument from the controls at the bottom of the UI.
     * These controls are (from left to right) Drop, Rotate X, Rotate Y, and
     * Rotate Z. 
     * These allow the user to drop the shape straight to the bottom of the 
     * play area and to rotate the shape around the three possible axis of
     * rotation.
     * 
     */
    public void UserInput(string action)
    {
        // Gets the shape.
        Shape shape = FindObjectOfType<ShapeCreator>().GetNextShape().GetComponent<Shape>();
        // Switch statement to perform the relevant action.
        switch (action)
        {
            // DROP SHAPE
            case "Drop":
                shape.DropShape();
                break;
            // DROP SHAPE ONE PLACE
            case "SmallDrop":
                shape.Drop();
                break;
            // ROTATE X-AXIS
            case "RotX":
                shape.RotateX();
                break;
            // ROTATE Y-AXIS
            case "RotY":
                shape.RotateY();
                break;
            // ROTATE Z-AXIS
            case "RotZ":
                shape.RotateZ();
                break;
        }
    }

    /*
     * Pause / Game Over Method. 
     * Sets the time scale to zero which effectively pauses
     * the game accept for controls, but sets a boolean so we can stop controls.
     * 
     * If the game has been paused the pause canvas is enabled, or if the game has 
     * been lost the game over canvas is enabled.
     * Boolean to decide which. 
     */
    public void PauseGameOver(bool gameOver)
    {
        Time.timeScale = 0;
        isGamePaused = true;
        gameCanvas.enabled = false;
        if (gameOver) 
        {
            gameOverCanvas.enabled = true;
        }
        else 
        {
            pauseCanvas.enabled = true;
        }
    }

    /*
     * Resume Game Method. 
     * Resumes the game if the play button is pressed. Exact opposite of the
     * pause game method.
     */
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseCanvas.enabled = false;
        gameCanvas.enabled = true;
    }

    /*
     * Restard Game Method.
     * If the relevant button is pressed then the active scene will be 
     * restarted.
     */
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Shape.fallSpeed = 3;
    }

    /*
     * Main Menu Method.
     * When the relevant button is pressed the menu scene is loaded.
     */
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}