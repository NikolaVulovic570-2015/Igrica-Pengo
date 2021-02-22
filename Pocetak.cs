using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pocetak : MonoBehaviour
{
    public Text pressEnter;
    void Start()
    {
        pressEnter = GetComponent<Text>();
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Igra");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
