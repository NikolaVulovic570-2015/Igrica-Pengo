using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class  Kockica : MonoBehaviour
{
    public Rigidbody2D rbb;
    public int smer;
    public float moveForce = 3f;
    public Vector2 moveDir;
    public int dodiruje;
    public Vector2 smerKock;
    public LayerMask whatIsEnemy;
    public LayerMask whatIsEnemy1;
    public LayerMask whatIsEnemy2;
    public float maxDistFromWall = 0.4f;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsCube;

    Vector2 pomeraj()
    {
        Vector2 temp = new Vector2();
        rbb = GetComponent<Rigidbody2D>();
        if ( smer == 1)
        {
            temp = transform.up;
        }

        else if (smer == 2)
        {      
            temp = -transform.up;
        }

        else if (smer == 3)
        {
            temp = -transform.right;
        }

        else if (smer == 4)
        {
            temp = transform.right;
        }
        return temp;
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Pingvin"))
        {
            dodiruje = 1;
            rbb.isKinematic = true;
        }

        if (col.gameObject.tag.Equals("Kockica"))
        {
            moveDir = new Vector2(0f, 0f);    
        }


    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Pingvin"))
        {
            dodiruje = 0; 
        }


    }


    void Update()
    {
        rbb.velocity = moveDir * moveForce;
        if (Physics2D.Raycast(transform.position, smerKock, maxDistFromWall, whatIsEnemy) && rbb.velocity.magnitude > 0.1)
        {
            Skor.score += 1000;
            Destroy(GameObject.FindWithTag("Neprijatelj"));   
        }

        if (Physics2D.Raycast(transform.position, smerKock, maxDistFromWall, whatIsEnemy1) && rbb.velocity.magnitude > 0.1)
        {
            Skor.score += 1000;
            Destroy(GameObject.FindWithTag("Neprijatelj1"));    
        }

        if (Physics2D.Raycast(transform.position, smerKock, maxDistFromWall, whatIsEnemy2) && rbb.velocity.magnitude > 0.1)
        {
            Skor.score += 1000;
            Destroy(GameObject.FindWithTag("Neprijatelj2"));  
        }

        if (Input.GetKeyDown(KeyCode.Space) && dodiruje == 1 && Physics2D.Raycast(transform.position, -smerKock, maxDistFromWall, whatIsPlayer))
        {
            moveDir = pomeraj();
        }

        if (Input.GetKeyDown(KeyCode.C) && dodiruje == 1 && Physics2D.Raycast(transform.position, -smerKock, maxDistFromWall, whatIsPlayer))
        {
            Skor.score += 400;
            Destroy(gameObject);
        }

        if (dodiruje == 1 && Physics2D.Raycast(transform.position, -smerKock, maxDistFromWall, whatIsPlayer))
        {
            rbb.isKinematic = true;   
        }

        if (dodiruje == 0)
        {
            rbb.isKinematic = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            smer = 1;
            smerKock = transform.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            smer = 2;
            smerKock = -transform.up;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            smer = 3;
            smerKock = -transform.right;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            smer = 4;
            smerKock = transform.right;
        }

       
    }
}
