using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    public int jumpForce;

    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");

        if ((moveHorizontal <0 && facingRight) || (moveHorizontal >0 && !facingRight))
        {

            Flip();
        }


      

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

       

        rigid.AddForce(movement * maxSpeed );
		
	}


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
