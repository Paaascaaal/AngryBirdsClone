using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 6f;

    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    void Die()
    {
        this.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<ParticleSystem>().Play();
        
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject,5f);
        
    }
}
