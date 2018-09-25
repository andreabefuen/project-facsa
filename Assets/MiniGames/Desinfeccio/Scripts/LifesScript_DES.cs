using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesScript_DES : MonoBehaviour
{//el objeto vida si toca el jugador suma vida
    private Rigidbody2D rBody;
    public float speed = 2f;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        rBody.velocity = Vector2.up * -speed;
      

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            audioSource.Play();
            SpriteRenderer sprite;
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            Destroy(gameObject, 4f);
            Manager_DES.Vides += 1;
        }
        else if (collision.gameObject.tag == "Water")
        {
            Destroy(gameObject);

        }
    }

}
