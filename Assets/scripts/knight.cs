using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{


    public int Speed;
    public Rigidbody2D PlayerRB;
    //public LayerMask layermask;
    public Animator PlayerAnim;
    public SpriteRenderer knightflip;
    public bool IsPlayerAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        knightflip = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.Translate(Vector2.up * Speed * Time.deltaTime);


        }

        
    }
    
   

   
}
