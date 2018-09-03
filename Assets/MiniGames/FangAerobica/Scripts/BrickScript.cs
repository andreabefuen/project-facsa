using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public int life;
    public Sprite secondColor;
    public GameObject oxigen;
    public bool haveOxygen;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        audioSource.Play();
        life -= 1;
        if (life == 1)
        {
            GetComponent<SpriteRenderer>().sprite = secondColor;
        }else if (life == 2)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
        else if (life <= 0)
         {
            if (haveOxygen)
            {
                Instantiate(oxigen, transform.position, transform.rotation);
            }
            BoxCollider2D coll;
            coll = GetComponent<BoxCollider2D>();
            coll.enabled = false;

            SpriteRenderer sprite;
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            Destroy(gameObject, 0.2f);
            Manager.Score += 100;
        }
    }
}
