using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public IteamController _score;
    public AudioSource FinishSoundEffect;

    private bool levelComplete = false;
    private void Start()
    {
        FinishSoundEffect = GetComponent<AudioSource>();
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplete)
        {
            if (_score.Apple == 5)
            {
                
                FinishSoundEffect.Play();
                levelComplete = true;
                Invoke("CompleteLevel", 2f);
               
            }
        }
    }
    public void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
