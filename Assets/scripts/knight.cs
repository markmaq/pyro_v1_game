using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class knight : MonoBehaviour
{


    public int Speed;
    public Rigidbody2D PlayerRB;
    //public LayerMask layermask;
    public Animator PlayerAnim;
    public SpriteRenderer knightflip;
    public bool isattacking = true;
    public bool IsJumping = true;
    public Animator jump;
    public Animator knightattack;
    public TextMeshProUGUI score;
    public int PlayerLife = 10;



    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        knightflip = GetComponent<SpriteRenderer>();
        jump = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerLife.ToString();
        



        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            knightflip.flipX = true;

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            knightflip.flipX = false;

        }
        if (Input.GetKey(KeyCode.W))
        {
            jump.Play("jump");
            transform.Translate(Vector2.up * Speed * Time.deltaTime);


        }
        if (Input.GetKey(KeyCode.F))
        {
            PlayerAnim.Play("knightattack");
            
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "orc")
        {
         PlayerLife -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "powerUp")
        {
            PlayerLife += 2;
            Destroy(collision.gameObject, 1);
        }
    }



}
