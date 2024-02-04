using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public float spawnSpeed = 1f;

    void Start()
    {
        
        InvokeRepeating("Spawn", spawnSpeed, 1f);
    }

    void Spawn()
    {
        var obj = Instantiate(fruitPrefab);
        var x = Random.Range(-5f,5f);
        obj.transform.position = new Vector3(x,-5,0);
    }
}
