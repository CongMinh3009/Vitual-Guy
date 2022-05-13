using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    //public static GameManager Instance
    //{
    //    get => _instance;
    //}
    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //    _instance = this;
    //}

   public void EndGame()
    {
        Debug.Log("GAME OVER");
    }
   

}
