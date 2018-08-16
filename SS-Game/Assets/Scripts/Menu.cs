using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

  //  public int levelOption; 

    public void ChooseLevel(int levelOption) {
        if (levelOption == 1) {
            SceneManager.LoadScene("GameLevel1");
        }
        else if (levelOption == 2)
        {
            SceneManager.LoadScene("GameLevel2");
        }
    }
}
