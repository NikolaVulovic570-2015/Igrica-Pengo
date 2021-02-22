using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pingvin : MonoBehaviour
{
    private float xInput, yInput;
    private bool isMoving;
    public float speed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    public Image Zivot1;
    public Image Zivot2;
    public Image Zivot3;
    public int brojZivota = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = false;    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Neprijatelj"))
        {
            StartCoroutine(animacijaSmrti());
        }

        if (col.gameObject.tag.Equals("Neprijatelj1"))
        {
            StartCoroutine(animacijaSmrti());
        }

        if (col.gameObject.tag.Equals("Neprijatelj2"))
        {
            StartCoroutine(animacijaSmrti());
        }
    }

    public void lifeCheck()
    {
        if (brojZivota == 2)
        {
            Zivot1.enabled = false;
        }
        if (brojZivota == 1)
        {
            Zivot2.enabled = false;
        }
        if (brojZivota == 0)
        {
            Zivot3.enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator animacijaSmrti()
    {
        brojZivota -= 1;
        Neprijatelj.move = 0f;
        Neprijatelj1.move = 0f;
        Neprijatelj2.move = 0f;
        animator.SetBool("Smrt", true);
        speed = 0f;
        yield return new WaitForSeconds(2f);
        animator.SetBool("Smrt", false);
        transform.position = new Vector3(0f, 0.3f);
        speed = 4f;
        Neprijatelj.move = 2f;
        Neprijatelj1.move = 2f;
        Neprijatelj2.move = 2f;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Gura", true); 
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Gura", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Gura", true);  
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Gura", false);
        }

        lifeCheck();

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        isMoving = (xInput != 0 || yInput != 0);

        if (isMoving)
        {
            var moveVector = new Vector3(xInput, yInput, 0);
            rb.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime),
           (transform.position.y + moveVector.y * speed * Time.deltaTime)));
            animator.SetFloat("SpeedUp", yInput);
            animator.SetFloat("Speed", xInput);
        }

    }
 }
