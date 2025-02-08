using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class KnightNew : MonoBehaviour
{
    Animator KnightAnim;
    Rigidbody2D KnightRB;
    [SerializeField] int Movementspeed;
    private SpriteRenderer knightflip;
    public Transform AttackPosition;
    public float AttackRadius;
    public LayerMask Orclayers;


    // Start is called before the first frame update
    void Start()
    {
        KnightRB = GetComponent<Rigidbody2D>();
        KnightAnim = GetComponent<Animator>();
        knightflip = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnJump()
    {
        Debug.Log("jump!");
        KnightAnim.Play("jump");
        KnightRB.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    private void OnMovements(InputValue inputvalue)
    {
        KnightRB.velocity = inputvalue.Get<Vector2>() * Movementspeed;
       
    }
    private void OnAttack()
    {
        Debug.Log("Attack!");
        KnightAnim.SetTrigger("IsAttack");
        Collider2D[] EnemyGotHit = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRadius);
        foreach(Collider2D hit in EnemyGotHit)
        {
            Debug.Log("EnemyGotHit");
           
        }

    }
}
