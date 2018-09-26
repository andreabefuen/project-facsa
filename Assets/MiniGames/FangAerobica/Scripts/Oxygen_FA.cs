using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_FA : MonoBehaviour
{
    private Rigidbody2D rBody;
    public float speed = 2f;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {//movimiento caida de esfera
        rBody.velocity = Vector2.up * -speed;
        //Store the current horizontal input in the float moveHorizontal.
        //Use the two store floats to create a new Vector2 variable movement.


    }
    void OnTriggerEnter2D(Collider2D collision)
    {//si toca al jugador se le suma
        if (collision.gameObject.name == "Player")
        {
            audioSource.Play();
            SpriteRenderer sprite;
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            CircleCollider2D col;
            col = GetComponent<CircleCollider2D>();
            col.enabled = false;
            Destroy(gameObject,1f);
            Manager_FA.Oxigen += 1;
        }
       
    }
    
}
