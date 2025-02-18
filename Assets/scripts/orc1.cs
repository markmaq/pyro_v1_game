using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orc1 : MonoBehaviour
{
    public float Distance;
    public float speed;
    public bool isORCmovingRight;
    public bool isORCmovingLeft;
    public Rigidbody2D OrcRB;
    public Animator OrcAnim;
    public float RayDistance;
    public LayerMask LayerMask;
    public Transform knight;
    public SpriteRenderer flip;
    public int Orclife = 3;
    public GameObject emblem;


    private Vector2 startposition;
    private Vector2 Orcdirection = Vector2.right;
    private float previousORCposition;


    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        previousORCposition = transform.position.x;
        OrcAnim = GetComponent<Animator>();
        OrcRB = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * speed) * (Distance / 2f);
        transform.position = new Vector2(startposition.x + offsetX, startposition.y);

        if (isORCmovingLeft)
        {

            Orcdirection = Vector2.left;
            flip.flipX = true;
        }
        if (isORCmovingRight)
        {
            Orcdirection = Vector2.right;
            flip.flipX = false;
        }


        DetectingPosition();

        RayDetection();

       

    }

    private void DetectingPosition()
    {
        float currentPlayerPosition = transform.position.x;

        if (currentPlayerPosition < previousORCposition)
        {

            //Debug.Log("orc moves left");
            isORCmovingLeft = true;
            isORCmovingRight = false;
        }

        else if (currentPlayerPosition > previousORCposition)
        {
            //Debug.Log("orc moves right");
            isORCmovingLeft = false;
            isORCmovingRight = true;

        }

        else
        {
            Debug.Log("Player is not moving");
        }

        //Update the previous position for the next frame
        previousORCposition = currentPlayerPosition;


    }

    private void RayDetection()
    {
        RaycastHit2D RayLaser = Physics2D.Raycast(transform.position, Orcdirection, RayDistance, LayerMask);
        Debug.DrawRay(transform.position, Orcdirection * RayDistance, Color.red);
        if (RayLaser)
        {
            followPlayer();
            if (RayLaser.distance < 1.5f)
            {
                OrcAnim.SetBool("isclosetotarget", true);
            }

        }
        if (!RayLaser)
        {
            OrcAnim.SetBool("isclosetotarget", false);
        }
    }

    private void followPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, knight.position, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "knight")
        {
            Orclife -= 1;
            if (Orclife < 1)
            {
                OrcAnim.SetBool("orcisdead", true);
                Instantiate(emblem, transform.position, Quaternion.identity);
                Destroy(this.gameObject, 1.5f);
               
            }

        }

    }

}
