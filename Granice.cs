using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granice: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.6f, 3.6f),
            Mathf.Clamp(transform.position.y, -4.5f, 3.89f), transform.position.z); 
    } 
}
