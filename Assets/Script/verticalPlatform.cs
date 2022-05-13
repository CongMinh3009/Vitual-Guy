using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalPlatform : MonoBehaviour
{
    [SerializeField] private PlatformEffector2D effector2D;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(waitTime <=0)
            {
                effector2D.rotationalOffset = 180f;
                waitTime = 0.5f;
            } 
            else
            {
                waitTime -= Time.deltaTime;
            }
        }    
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            effector2D.rotationalOffset = 0f;
        }
    }
}
