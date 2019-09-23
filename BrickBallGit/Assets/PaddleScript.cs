using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);

        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector3(leftScreenEdge, transform.position.y);
        }
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector3(rightScreenEdge, transform.position.y);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!" + other.name);
        if (other.CompareTag("ExtraLife"))
        {
            audio.Play();
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }

        }
}
