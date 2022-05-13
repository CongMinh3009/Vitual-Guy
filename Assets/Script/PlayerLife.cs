using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool die = false;
    [SerializeField] GameObject LoserUI;
    [SerializeField] PlayerController player;
   
    //[SerializeField] AudioSource DieSoundEffect;

    public bool Hurt { get => die; set => die = value; }


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            player.AudioDiePlay();         
            Die();
        }
    }
    public void Die()
    {
        die = true;
        rb.bodyType = RigidbodyType2D.Static; 
        anim.SetTrigger("isDeath");
       
    }
    public  void RestartLevel()
    {
        LoserUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene() .name);
    }    
}
