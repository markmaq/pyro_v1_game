using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngineInternal;


public class KnightNew : MonoBehaviour
{
    Animator KnightAnim;
    Rigidbody2D playerRB;
    [SerializeField] int Movementspeed;
    private SpriteRenderer playerFlip
        ;
    public Transform AttackPosition;
    public float AttackRadius;
    public LayerMask Orclayers;

    public bool isPlayerBoost = false;
    public bool isWalking = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        KnightAnim = GetComponent<Animator>();
        playerFlip = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       if(isPlayerBoost)
        {
            Movementspeed = 10;
        }

        if (!isPlayerBoost)
        {
            Movementspeed = 5;
        }
    }
    private void OnJump()
    {
        Debug.Log("jump!");
        KnightAnim.Play("jump");
        playerRB.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    private void OnMovements(InputValue inputvalue)
    {
        playerRB.velocity = inputvalue.Get<Vector2>() * Movementspeed;
        PlayerMovementTracker();
        KnightAnim.SetTrigger("isWalking");

    }
    private void OnAttack()
    {
       
            Debug.Log("Attack!");
            KnightAnim.SetTrigger("isAttacking");
            Collider2D[] EnemyGotHit = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRadius);
            foreach (Collider2D hit in EnemyGotHit)
            {
                Debug.Log("EnemyGotHit");

            }
        
        

    }
    void PlayerMovementTracker()
    {
        if (playerRB.velocity.x < 0)
        {
            //Debug.Log("Player is moving left");
            playerFlip.flipX = true;
        }

        else if (playerRB.velocity.x > 0)
        {
            //Debug.Log("Player is moving right");
            playerFlip.flipX = false;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boost")
        {
            StartCoroutine(PowerUp());
            Destroy(collision.gameObject,1f);
        }
    }
    IEnumerator PowerUp()
    {
        isPlayerBoost = true;
        yield return new WaitForSeconds(5.0f);
        isPlayerBoost = false;

    }
}
