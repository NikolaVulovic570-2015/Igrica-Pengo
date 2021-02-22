using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Smrt : MonoBehaviour
{
    private Vector2 Position;
    public Image Zivot1;
    public Image Zivot2;
    public Image Zivot3;
    public int brojZivota = 3;
    public Rigidbody2D rb;
    public GameObject Pingvin;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Neprijatelj"))
        {
            smrt();
        }

        if (col.gameObject.tag.Equals("Neprijatelj1"))
        {
            smrt();
        }

        if (col.gameObject.tag.Equals("Neprijatelj2"))
        {
            smrt();
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
        }
    }

    public void smrt()
    {
        brojZivota -= 1;
        Destroy(Pingvin);
        Instantiate(Pingvin);

    }

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeCheck();
       
    }

}