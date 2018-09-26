using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer_FA : MonoBehaviour {

    public float speed;
    public Vector3 velocity;
    private Rigidbody2D rBody;
    // Use this for initialization
    void Start()
    {
        velocity = Vector3.zero;
        rBody = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {//movimiento de la pala
        //Store the current horizontal input in the float moveHorizontal.
        velocity.x = Input.GetAxis("Horizontal");
        //Use the two store floats to create a new Vector2 variable movement.
        rBody.velocity = transform.TransformDirection(velocity * speed);


    }

}
