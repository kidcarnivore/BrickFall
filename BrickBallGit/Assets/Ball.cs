using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform powerUp;
    AudioSource audio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver)
        {
            return;
        }


        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if(Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector3.up * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottom"))
        {
            Debug.Log("Ball Exit");
            rb.velocity = Vector3.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Brick"))
           {
            Bricks brickScript = collision.gameObject.GetComponent<Bricks>();

            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {



                int randChance = Random.Range(1, 101);
                if (randChance < 50)
                {
                    Instantiate(powerUp, collision.transform.position, collision.transform.rotation);
                }

                Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(brickScript.points);
                gm.UpdateBricks();

                Destroy(collision.gameObject);
            }
            audio.Play();
           }

        
    }
}
