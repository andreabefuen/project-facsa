using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_DES : MonoBehaviour {
    int moveCount;
    private Rigidbody2D rBody;
    private PolygonCollider2D tCollider;
    public float speed;
    public GameObject bullet;
    public GameObject Healt;
    public GameObject Lifes;
    public AudioClip explosionClip;
    public Vector3 velocity;
    public bool orientacion;
    public int score = 100;
    int timeShoot;
    bool destroyed;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        destroyed = false;
        moveCount = 75;
        velocity = Vector3.zero;
        rBody = GetComponent<Rigidbody2D>();
        speed = 0.5f;
        timeShoot = UnityEngine.Random.Range(20, 500);
        audioSource = GetComponent<AudioSource>();
        tCollider = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!destroyed)
        {//si no es destruido se mueve y dispara cada cierto tiempo
            if (moveCount > 0)
            {
                if (orientacion)
                {
                    velocity.x = 1;
                    rBody.velocity = transform.TransformDirection(velocity * speed);
                }
                else
                {
                    velocity.x = -1;
                    rBody.velocity = transform.TransformDirection(velocity * speed);

                }
                moveCount -= 1;
            }
            else
            {
                velocity.y = -3;
                velocity.x = 0;
                rBody.velocity = transform.TransformDirection(velocity * speed);
                velocity.y = 0;
                orientacion = !orientacion;
                moveCount = 75;
            }
            if (timeShoot == 0)
            {
                if (Manager_DES.EnemyBullets <= Manager_DES.MaxBullets)
                {
                    timeShoot = UnityEngine.Random.Range(120, 240);
                    Shoot();
                }
                else
                {
                    timeShoot = UnityEngine.Random.Range(90, 180);

                }
            }
            else
            {
                timeShoot -= 1;
            }
        }
        else
        {
            velocity.y = 0;
            velocity.x = 0;
            rBody.velocity = transform.TransformDirection(velocity * speed);
        }
    }

    void Shoot()
    {//dispara
        audioSource.Play();
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
        Instantiate(bullet, pos, bullet.transform.rotation);
    }
    public void Destruido()
    {//cuando es destruido reproduce sonido y oculta colider y sprite pero espera a destruirse cuando acaba el sonido calcula unr andom apra lanzar objeto
        destroyed = true;
        tCollider.enabled = false;
        SpriteRenderer sprite;
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        audioSource.clip = explosionClip;
        audioSource.Play();
        Manager_DES.Score += score;
        Manager_DES.EnemiesInScene -= 1;
        int objectProb = UnityEngine.Random.Range(0, 100);
        if (objectProb > 90)
            Instantiate(Healt, transform.position, transform.rotation);
        else if (objectProb < 3)
            Instantiate(Lifes, transform.position, transform.rotation);
        Destroy(gameObject, 0.5f);
        
    }
}
