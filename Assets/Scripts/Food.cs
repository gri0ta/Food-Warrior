using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    Rigidbody2D rb;
   // public Rigidbody2D fruit;
    public GameObject fruits;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 11);
        //InvokeRepeating("LaunchFruit", 2.0f, 0.3f);
        InvokeRepeating("SpawnObject", 0.0f, Random.Range(minSpawnTime, maxSpawnTime));
    }
    void SpawnObject()
    {
        // Instantiate the prefab at the spawner's position
        Instantiate(fruits, transform.position, Quaternion.identity);

        // Reschedule the next spawn with random timing
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
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
