using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject RestartButton;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }


    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PointManager.currentPoint=0;
        Player_controller.characterHealth=3f;
        Time.timeScale = 1f;
        isGamePaused = false;
        Debug.Log(GameOver.isGameOver);
    }

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused= false;
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
    }

    public void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);

    }

    public void QuitGame(){
        Debug.Log("game is quitting");
        Application.Quit();
    }
}
