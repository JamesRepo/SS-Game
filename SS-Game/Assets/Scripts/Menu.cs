using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    /*
     * ==== Menu ====
     * --------------
     * Class to handle the menu at the start of the game. 
     * Loads the relative scene.
     * 
     */
public class Menu : MonoBehaviour {

    /*
     * 
     * ==== Variables ====
     * 
     */

    // Assigns the Unity object that will show the high score.
    public Text highScoreMenu;

    /*
     * 
     * ==== Unity Functions ====
     * 
     */

    // Initialisation. Makes sure the current high score is there.
    public void Start() {
        UpdateHighScore();
    }


    /*
     * 
     * ==== Methods ====
     * 
     */

    // Gets the saved high score.
    public void UpdateHighScore() {
        highScoreMenu.text = PlayerPrefs.GetInt("highscore").ToString();
    }
    // Goes to the main game.
    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }
    // Goes to the training level. 
    public void Training() {
        SceneManager.LoadScene("Training");
    }
}
