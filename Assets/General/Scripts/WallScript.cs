using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D wallCollider;
    ParticleSystem destroyParticles;
    AudioSource wallBreak;
    [SerializeField] AudioClip[] wallBreakSounds;

    [SerializeField] private float _minVel; 

    private float _minPitch, _maxPitch;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sprite = this.GetComponent<SpriteRenderer>();
        wallCollider = this.GetComponent<Collider2D>();
        destroyParticles = this.GetComponent<ParticleSystem>();
        wallBreak = this.GetComponent<AudioSource>();

        _minVel = 5.0f;
        _minPitch = 0.85f;
        _maxPitch = 1.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= _minVel)
        {
            gameManager.IncreaseScore(3);
            gameManager.SetHighscore();
            int wallBreakClip = Random.Range(0, wallBreakSounds.Length);
            wallBreak.clip = wallBreakSounds[wallBreakClip];
            wallBreak.pitch = Random.Range(_minPitch, _maxPitch);
            wallBreak.Play();
            

            sprite.enabled = false;
            wallCollider.enabled = false;
            if (destroyParticles != null)
            {
                destroyParticles.Play();
            }
            Destroy(gameObject, 2f);
        }
    }
}
