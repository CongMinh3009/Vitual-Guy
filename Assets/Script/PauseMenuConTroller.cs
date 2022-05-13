using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuConTroller : MonoBehaviour
{
    public static bool GameIsPause = false;
    [SerializeField] GameObject pauseGameMenuUI;
    [SerializeField] PlayerLife player;
   
    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape) && !player.Hurt)
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   public void Resume()
    {
        pauseGameMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    void Pause()
    {
        pauseGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }   
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
    public void Quit()
    {
        Application.Quit();
    }
}
