using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public int bombChance = 20;
    public GameObject bombPrefab;
    public float spawnSpeed = 1f;

    void Start()
    {
        
        InvokeRepeating("Spawn", spawnSpeed, 1f);
    }

    void Spawn()
    {
        var chance = Random.Range(0, 100);
        var prefab = chance > bombChance ? fruitPrefab : bombPrefab; //veikia kaip if ir isrenka arba bomb arba fruit

        var obj = Instantiate(prefab);
        var x = Random.Range(-5f,5f);
        obj.transform.position = new Vector3(x,-5,0);
    }
}
