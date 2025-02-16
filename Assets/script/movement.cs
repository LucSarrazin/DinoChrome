using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
public bool GameOver;

     private Rigidbody2D rb;
     private BoxCollider2D box;
     public PolygonCollider2D WalkCollider;
     public PolygonCollider2D CrouchCollider;

     public float jump;
     public AudioSource jumpSound;
     public AudioSource GameOverSound;
     public AudioClip gameoverclip;
     public Animator anim;

     public bool OneTime = false;
     public bool DoobleJump;
     public bool touchGround;
     public float score;
     public Text scoreText;
     public Text highScoreText;
     
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim.SetBool("StartGame", true);
        highScoreText.text = "HighScore : " + (int) PlayerPrefs.GetFloat("HighScore");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == false)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = "Score : " + (int)score;
        }
        if (Input.GetButtonDown("Jump") && GameOver == false && touchGround == true)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(0, jump);

        }
        
        
        if (Input.GetButtonDown("Jump") && DoobleJump == true && touchGround == false)
        {
            DoobleJump = false;
            jumpSound.Play();
            rb.velocity = new Vector2(0, jump);
        }
        
        
        if (Input.GetKey(KeyCode.DownArrow) && GameOver == false)
        {
            box.size = new Vector2(0.262154073f,0.211788833f);
           // CrouchCollider.enabled = true;
            anim.SetBool("Crouch", true);

        }
        else
        {
            box.size = new Vector2(0.17744258f, 0.372523785f);
           // WalkCollider.enabled = true;
            anim.SetBool("Crouch", false);
        }

        if (GameOver == true)
        {
            anim.SetBool("GameOver", true);
            if (score > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", score);
            }
            CrouchCollider.enabled = false;
            WalkCollider.enabled = false;
            box.enabled = false;
            transform.position = new Vector2(-9.19999981f,-2.65300012f);
            anim.SetBool("StartGame", false);
            if (!OneTime)
            {
                GameOverSound.PlayOneShot(gameoverclip);
                OneTime = true;
            }
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            
                touchGround = true;
                DoobleJump = true;


        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            touchGround = false;

        }
    }
}
