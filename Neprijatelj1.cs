using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Neprijatelj1 : MonoBehaviour
{
    public static float move = 2f;
    public float moveForce;
    public Vector2 moveDir;
    public LayerMask whatIsWall;
    public LayerMask whatIsAlly;
    public LayerMask whatIsAlly1;
    public float maxDistFromWall = 0f;
    public Rigidbody2D rb;
    public Animator animator;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDir = ChooseDirection();
    }


    private void Update()
    {
        moveForce = move;
        Pingvin obj = new Pingvin();
        rb.velocity = moveDir * moveForce;

        if (Physics2D.Raycast(transform.position, moveDir, maxDistFromWall, whatIsWall))
        {
            moveDir = ChooseDirection();

        }

        if (Physics2D.Raycast(transform.position, moveDir, maxDistFromWall, whatIsAlly))
        {
            moveDir = ChooseDirection();

        }

        if (Physics2D.Raycast(transform.position, moveDir, maxDistFromWall, whatIsAlly1))
        {
            moveDir = ChooseDirection();

        }
    }

    Vector2 ChooseDirection()
    {
        System.Random rnd = new System.Random();
        int i = rnd.Next(0, 4);
        Vector2 temp = new Vector2();


        if (i == 0)
        {
            temp = transform.up;
            animator.SetFloat("Anim1", 0);
            animator.SetFloat("Anim", 1);
        }
        else if (i == 1)
        {
            temp = -transform.up;
            animator.SetFloat("Anim1", 0);
            animator.SetFloat("Anim", -1);
        }
        else if (i == 2)
        {
            temp = transform.right;
            animator.SetFloat("Anim", 0);
            animator.SetFloat("Anim1", 1);
        }
        else if (i == 3)
        {
            temp = -transform.right;
            animator.SetFloat("Anim", 0);
            animator.SetFloat("Anim1", -1);
        }

        return temp;
    }





}
