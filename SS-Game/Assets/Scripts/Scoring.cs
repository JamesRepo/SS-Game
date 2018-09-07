using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ==== Scoring ====
 * Class to handle the scoring in game.
 * 
 */

public class Scoring : MonoBehaviour {

    /*
     * 
     * ==== Variables ====
     * 
     */

    // Scores for the different ways.
    private const int scoreLand = 50;
    private const int scoreClearOne = 200;
    private const int scoreClearTwo = 600;
    private const int scoreClearThree = 1800;
    // Counters
    private int levelsClearedCounter;
    private int scoreCounter;
    // Used to check if current score has over taken the old one. 
    private int currentHighScore;
    // Assigned in Unity editor. Used for displaying scores.
    public Text highScore, scoreText, levelText;
    // Boolean to check if in training mode, scoring doesn't count in training mode. 
    public bool training;

    /*
     * 
     * ==== Unity Functions ====
     * 
     */

    // Initialisation
    private void Start() {
        levelsClearedCounter = 0;
        scoreCounter = 0;
        currentHighScore = PlayerPrefs.GetInt("highscore");
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    /*
     * 
     * ==== Methods ====
     * 
     */

    // Updates the score when a score happens and checks if the new score has beaten the current high score. 
    public void UpdateAndCheck() {
        scoreText.text = scoreCounter.ToString();
        NewHighScore();
    }

    // Adds the score for landing to total score. 
    public void LandScore() {
        if (!training) {
            scoreCounter += scoreLand;
            UpdateAndCheck();
        }        
    }
    // Adds the score for clearing a row to total score. 
    public void RowClearScore(int rowNum) {
        if (!training) {
            switch (rowNum) {
                case 1:
                    scoreCounter += scoreClearOne;
                    break;
                case 2:
                    scoreCounter += scoreClearTwo;
                    break;
                case 3:
                    scoreCounter += scoreClearThree;
                    break;
            }
            UpdateAndCheck();
        }
    }
    // Increments the counter for the amount of levels cleared.
    public void IncrementLevelCounter() {
        levelsClearedCounter++;
        levelText.text = levelsClearedCounter.ToString();
    }
    // Checks if the current score is beating the high score. 
    public void NewHighScore() {
        if (scoreCounter > currentHighScore) {
            PlayerPrefs.SetInt("highscore", scoreCounter);
            highScore.text = scoreCounter.ToString();
        }
    }
}