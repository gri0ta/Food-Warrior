using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;
    public int comboCount;
    public float comboTimeLeft;
    public AudioClip comboSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        //transform.position = worldPos;

        rb.MovePosition(worldPos);

        //COMBO
        comboTimeLeft -= Time.deltaTime;
        if (comboTimeLeft <=0)
        {
            if (comboCount>2)
            {
                //GameManager.score+=3;
               AudioSystem.Play(comboSound);
            }
            comboCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(":)");
        var food = collision.gameObject.GetComponent<Food>();
        food.Slice();
        comboCount++;
        comboTimeLeft = 0.3f;
    }
}
