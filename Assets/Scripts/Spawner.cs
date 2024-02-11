using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodEntry
{
    public bool isBomb;
    public float x;
    public float delay;
    public bool isRandomPosition;
    public Vector2 velocity = new Vector2(0f,10f);
}

[System.Serializable]
public class Wave
{
    public List<FoodEntry> foods;
    
}
public class Spawner : MonoBehaviour
{
    public List<GameObject> fruitPrefabs;
    public int bombChance = 20;
    public GameObject bombPrefab;
    public float spawnSpeed = 1f;

    public int currentWave;
    public List<Wave> waves;

    async void Start()
    {
        //InvokeRepeating("Spawn", spawnSpeed, 1f);
        while (currentWave < waves.Count)
        {
            var wave = waves[currentWave]; //dabartinis wave
            for (int i = 0; i < wave.foods.Count; i++) 
            {
                var food = wave.foods[i]; //einam per savo fruits tam wave
                await new WaitForSeconds(food.delay);
                var randomFruits = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
                var prefab = food.isBomb ? bombPrefab : randomFruits;
                var go = Instantiate(prefab);
                go.transform.position = food.isRandomPosition ? new Vector3(Random.Range(-7f,7f),-5,0):new Vector3(food.x, -5, 0);
                go.GetComponent<Rigidbody2D>().velocity = food.velocity;
            }
            await new WaitForSeconds(3f);
            currentWave++;
        }

    }


}
