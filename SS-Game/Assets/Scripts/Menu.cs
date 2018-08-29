using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Text highScoreMenu;

    private void Start() {
        UpdateHighScore();
    }

    public void UpdateHighScore() {
        highScoreMenu.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

    public void Help() {
        SceneManager.LoadScene("Help");
    }
}
