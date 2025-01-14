using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explodeParticles;

    public GameObject leftSide;
    public GameObject rightSide;
    public Color juiceColor;
    public AudioClip throwSound;
    public AudioClip sliceSound;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0, Random.Range(7f,13f));
        rb.angularVelocity = Random.Range(-360f,360f);
        AudioSystem.Play(throwSound);
    }
    
    void Update()
    {
        if (transform.position.y < -7.3)
        {
            Miss();
        }
    }
    
    void Miss()
    {
        print(":(");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;
        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.GetComponentsInChildren<ParticleSystem>()[1].startColor = juiceColor;

        transform.DetachChildren();
        var leftRb = leftSide.AddComponent<Rigidbody2D>();
        var rightRb = rightSide.AddComponent<Rigidbody2D>();
        leftRb.velocity = rb.velocity + new Vector2(-2,0);
        rightRb.velocity = rb.velocity + new Vector2(3,0);
        leftRb.angularVelocity = -100;
        rightRb.angularVelocity = 100;

        AudioSystem.Play(sliceSound);
        GameManager.score++;
        
        Destroy(gameObject);
    }

}
