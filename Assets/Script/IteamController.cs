using UnityEngine;
using UnityEngine.UI;

public class IteamController : MonoBehaviour
{
    private int apple = 0;
   
    [SerializeField] private Text appleText;
    [SerializeField] PlayerController player;

    public int Apple { get => apple; set => apple = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Apple"))
        {
            player.AudioCollection();
            Destroy(collision.gameObject);
            apple++;
            appleText.text = $"Apple : {apple}/5" ;
        }    
    }
    // Start is called before the first frame update


}
