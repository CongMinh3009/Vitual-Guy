using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButtoon()
    { 
        Application.Quit();
        Debug.Log("Game Closed");
    }    
    public void StarGame()
    {
        SceneManager.LoadScene("PlayGame");
    }    
}
