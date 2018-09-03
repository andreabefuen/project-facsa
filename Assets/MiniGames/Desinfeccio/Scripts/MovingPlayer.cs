using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour {

    public float speed;
    public GameObject bullet;
    public Vector3 velocity;
    private Rigidbody2D rBody;
    AudioSource audioShoot;
    // Use this for initialization
    void Start()
    {
        velocity = Vector3.zero;
        rBody = GetComponent<Rigidbody2D>();
        audioShoot = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (Input.GetButtonDown("FireDesinfeccio"))
            Shoot();
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        velocity.x = Input.GetAxis("Horizontal");
        //Use the two store floats to create a new Vector2 variable movement.
        rBody.velocity = transform.TransformDirection(velocity * speed);


    }
    void Shoot() {
        audioShoot.Play();
        Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.5f, 0);
        Instantiate(bullet, pos, bullet.transform.rotation);
    }
}
