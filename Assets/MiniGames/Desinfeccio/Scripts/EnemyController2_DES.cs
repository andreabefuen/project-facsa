using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2_DES : MonoBehaviour
{
    public float speed = 5f;
    public int score = 100;
    public GameObject Healt;
    public GameObject Lifes;
    public AudioClip splashClip;
    AudioSource audioSource;
    bool destroyed;
    private PolygonCollider2D tCollider;

    void Start()
    {
        destroyed = false;
        audioSource = GetComponent<AudioSource>();
        tCollider = GetComponent<PolygonCollider2D>();

    }
    void FixedUpdate()
    {//se mueve
        if(!destroyed)
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

    }
    void OnTriggerEnter2D(Collider2D collision)
    {//si colisiona con el jugador resta vida si apsa de alrgo contamina el agua
        if (collision.gameObject.tag == "Player")
        {
            if (Manager_DES.Vides > 0)
            {
                Manager_DES.Vides -= 1;
            }
            else
            {
                Manager_DES.Vides -= 1;
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Water")
        {
            if (Manager_DES.Contaminacio > 0)
            {
                Manager_DES.Contaminacio -= 10;
            }
            audioSource.clip = splashClip;
            audioSource.Play();
            Destroy(gameObject,3f);

        }
    }
    public void Destruido()
    {//cuando es destruido reproduce sonido y oculta colider y sprite pero espera a destruirse cuando acaba el sonido calcula unr andom apra lanzar objeto

            destroyed = true;
        tCollider.enabled = false;
        SpriteRenderer sprite;
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        audioSource.Play();
        Manager_DES.Score += score;
        int objectProb = UnityEngine.Random.Range(0, 100);
        if (objectProb > 85)
            Instantiate(Healt, transform.position, transform.rotation);
        else if (objectProb < 5)
            Instantiate(Lifes, transform.position, transform.rotation);
        Destroy(gameObject, 0.5f);
    }
}
