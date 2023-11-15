using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;
    public static bool isGameOver = false;

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverUI.SetActive(false);
        PointManager.currentPoint=0;
        Player_controller.characterHealth=3f;
        Time.timeScale = 1f;
        isGameOver=false;
        Debug.Log("game is restarting");
    }

    

    public void QuitGame(){
        Debug.Log("game is quitting");
        Application.Quit();
    }
}
