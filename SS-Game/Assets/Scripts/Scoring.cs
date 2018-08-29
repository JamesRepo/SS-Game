using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    private const int scoreLand = 50;
    private const int scoreClearOne = 200;
    private const int scoreClearTwo = 600;
    private const int scoreClearThree = 1800;

    private int levelsClearedCounter;
    private int scoreCounter;

    private int currentHighScore;
    // Assigned in Unity editor.
    public Text highScore, scoreText, levelText;

    private void Start() {
        levelsClearedCounter = 0;
        scoreCounter = 0;
        currentHighScore = PlayerPrefs.GetInt("highscore");
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void UpdateAndCheck() {
        scoreText.text = scoreCounter.ToString();
        NewHighScore();
    }

    public void LandScore() {
        scoreCounter += scoreLand;
        UpdateAndCheck();
    }

    public void RowClearScore(int rowNum) {
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


    public void IncrementLevelCounter() {
        levelsClearedCounter++;
        levelText.text = levelsClearedCounter.ToString();
    }

    public void NewHighScore() {
        if (scoreCounter > currentHighScore) {
            PlayerPrefs.SetInt("highscore", scoreCounter);
            highScore.text = scoreCounter.ToString();
        }

    }
 
}
