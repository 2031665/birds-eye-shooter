using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;

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

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused= false;
    }

    void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void QuitGame(){
        Debug.Log("game is quitting");
    }
}
