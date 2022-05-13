using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Header("For Movement")]
    public bool facingRight ;
    public float MaxSpeed;
    public float MoveDirection;
    public bool isMoving;
    public float airMoveSpeed = 30f;
    public bool Falling;

    [Header("Other")]
    public Animator anim;
    public Rigidbody2D myBody;
    [Header("For Jumping")]
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    public Vector2 groundcheckSize; 
    public float JumpHeight;
    public bool grounded;
    public bool canJump;
    [Header("For WallSliding")]
    public float WallSlideSpeed;
    public LayerMask wallLayer;
    public Transform wallCheckPoint;
    public Vector2 wallCheckSize;
    public bool isTouchingWall;
    public bool isWallSilding;
    [Header("For WallJumpping")]
    public float wallJumpForce;
    public float wallJumpDirection = -1;
    public Vector2 wallJumpAngle;


    [Header("Sound")]
    [SerializeField] public AudioSource jumpSoundEffect;
    [SerializeField] private AudioClip _clipJump;
    [SerializeField] private AudioClip _clipDie;
    [SerializeField] private AudioClip _clipCollection;
    [Header("PlayerData")]
    [SerializeField] private PlayerData _configdata;



    #region Movement
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        facingRight = true;
        wallJumpAngle.Normalize();
        MaxSpeed = _configdata._maxSpeed;
        JumpHeight = _configdata._jumpHeight;
        
    }

    // Update is called once per frame 
    void Update()
    {
        InPuts();
        CheckWorld();
       
    }
    private void FixedUpdate()
    { 
        Movement();
        Jump();
        AnimationCtrl();
        WallSidle();
        WallJump();
    }

    void CheckWorld()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundcheckSize, 0, groundLayer);
        isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);

    }
    void InPuts()
    {
        MoveDirection = Input.GetAxis("Horizontal");
        //myBody.velocity = new Vector2(Move * MaxSpeed, myBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (grounded ||isTouchingWall) )
        {
            canJump = true;
           
        }
      
    }
    void Movement()
    {
        //for animation
        MoveDirection = Input.GetAxis("Horizontal");

        if (MoveDirection != 0 )
        {
            
            isMoving = true;
        }
        else { isMoving = false; } 

        //for flipping
        if (MoveDirection > 0 && !facingRight)
        {
            Flip();
        }
        else if (MoveDirection < 0 && facingRight)
        {
            Flip();
        }
        //for Falling
        if(myBody.velocity.y < 0)
        {
            Falling = true;
            anim.SetBool("isJump", false);
        }
        else
        {
           
            anim.SetBool("isJump", true);
            Falling = false;
        }
        if (myBody.velocity.y > .1f)
        {

            anim.SetBool("isJump", true);
        }
        //for movement
        if (grounded)
        {
            myBody.velocity = new Vector2(MoveDirection * MaxSpeed, myBody.velocity.y);
            //if (myBody.velocity.y < -1f)
            //{
            //    isMoving = false;
            //}
        }
        else if (!grounded && !isWallSilding && MoveDirection != 0)
        {
            myBody.AddForce(new Vector2(airMoveSpeed * MoveDirection, 0));
            if(Mathf.Abs(myBody.velocity.x) > MaxSpeed)
            {
                myBody.velocity = new Vector2(MoveDirection * MaxSpeed, myBody.velocity.y);
            }
        }
       
       
    }
    void Jump()
    {
       
          if (canJump && grounded)
          {
            jumpSoundEffect.PlayOneShot(_clipJump);
            //anim.SetBool("isGround", grounded);
            myBody.velocity = new Vector2(myBody.velocity.x, JumpHeight);
            canJump = false;
            isMoving = false;
          }
           
    }
    void WallSidle()
    {
        if(isTouchingWall && !grounded && myBody.velocity.y < 0)
        {
            isWallSilding = true;
        }
        else
        {
            isWallSilding = false;
        }
        if(isWallSilding)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, WallSlideSpeed);
        }
    }
    void WallJump()
    {
        if((isWallSilding || isTouchingWall ) && canJump)
        {
            jumpSoundEffect.PlayOneShot(_clipJump);

            myBody.AddForce(new Vector2(wallJumpForce * wallJumpDirection * wallJumpAngle.x, wallJumpForce * wallJumpAngle.y), ForceMode2D.Impulse);
            Flip();
            canJump = false;
            isMoving = false;
        }
    }
    void AnimationCtrl()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGround", grounded);
        anim.SetBool("isTouchingWall", isTouchingWall);
        anim.SetBool("isFalling", Falling);
       
    }
    void Flip() // lật face  player
    {
        wallJumpDirection *= -1;
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected
    private void OnDrawGizmosSelected()
    {
        //check ground
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPoint.position, groundcheckSize);
        //check wall
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);
    }


    #endregion 
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)

    

    [ContextMenu("ChangeScene")]

    private void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void AudioDiePlay()
    {
        jumpSoundEffect.PlayOneShot(_clipDie);
    }

    public void AudioCollection()
    {
        jumpSoundEffect.PlayOneShot(_clipCollection);
    }
}
