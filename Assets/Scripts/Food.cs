using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    Rigidbody2D rb;
   // public Rigidbody2D fruit;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 11);
        
    }
    
    void Update()
    {
        if (transform.position.y < -7.3)
        {
            print(":(");
            Destroy(gameObject);
        }
    }
    

}
