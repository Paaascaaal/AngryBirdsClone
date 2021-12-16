using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Variables

    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public GameObject[] nextBirdPrefab;
    public GameObject spawnPoint;
    GameObject inst;

    SpriteRenderer birdSprite;


    public float releaseTime = 0.15f;
    public float maxDragDistance = 1.8f;
    public float nextBird = 2.5f;
    public int randomBird;

    public float decayTimeBird = 8f;
    public float destroyTimeScript = 2.5f;

    Animator animator;

    [SerializeField] AudioClip[] warCries;

    
    GameObject obj;
    
    int i = 0;

    #endregion
    //public Transform hooky;


    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindWithTag("Special");
        obj.GetComponent<LvlSpecialities>();
        //lvlSpecialities = gameObject.AddComponent<LvlSpecialities>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        birdSprite = gameObject.GetComponent<SpriteRenderer>();
        InvokeRepeating("DestroyMe", 3, 3);

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnMouseDrag()
    {

        if (this.enabled)
        {
            rb.isKinematic = true;

            rb.freezeRotation = true;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + ((mousePos - hook.position).normalized) * maxDragDistance;

                


                //transform.right = hook.transform.position - this.transform.position;

            }
            else
            {
                mousePos.x += 0.1f;
                rb.position = mousePos;
                
                



                //transform.right = hook.transform.position - this.transform.position;


            }
        }

           

        
        

        

        
    }


 

    private void OnMouseUp()
    {
        
        rb.freezeRotation = false;
        animator.SetBool("isFlying", true);

        if (this.enabled)
        {
            
            rb.isKinematic = false;
            StartCoroutine(Release());
            
        }

    }

   

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        this.GetComponent<SpringJoint2D>().enabled = false;

        int releaseClip = Random.Range(0, warCries.Length);

        this.GetComponent<AudioSource>().clip = warCries[releaseClip];

        this.GetComponent<AudioSource>().pitch = Random.Range(1.2f, 1.8f);

        this.GetComponent<AudioSource>().Play();

        Destroy(this,destroyTimeScript);

        obj.GetComponent<LvlSpecialities>().MinusLvlBirds();

        this.enabled = false;

        if (obj.GetComponent<LvlSpecialities>().GetLevelBirds() > 0)
        {

            yield return new WaitForSeconds(nextBird);

            randomBird = Random.Range(0, nextBirdPrefab.Length);
            inst = Instantiate(nextBirdPrefab[randomBird], spawnPoint.transform.position, nextBirdPrefab[randomBird].transform.rotation);
            inst.GetComponent<SpringJoint2D>().enabled = true;
            inst.GetComponent<Player>().enabled = true;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if ((collision.gameObject.tag != "Bird"))
        {
            i++;
            this.GetComponent<AudioSource>().pitch = Random.Range(2.0f, 2.5f);
            if (i == 1)
            {
                animator.SetBool("isDead", true);
                
                this.GetComponent<ParticleSystem>().Play();

                StartCoroutine(decayWaiter());

                Physics2D.IgnoreLayerCollision(7, 7);

                Destroy(gameObject, 10f);

                
            }
            
        }

    }

    void DestroyMe()
    {
            if (gameObject.transform.position.x > 10 || gameObject.transform.position.x < -10)
            {
                Destroy(gameObject, 10f);
            }
        
    }

    private IEnumerator decayWaiter()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("shouldDecay", true);
    }

    



}
