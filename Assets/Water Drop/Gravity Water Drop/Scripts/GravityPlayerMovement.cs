using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlayerMovement : MonoBehaviour {

    public float maxSpeed = 10f;

    public float jumpForce;

    private Rigidbody2D rigid;
    private bool onGround = false;
    private bool onAir = true;
    private bool jumping = false;
    private bool facingRight = true;
    private Animator anim;

    private GameObject diePanel;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        diePanel = GameObject.Find("DiePanel");
        diePanel.SetActive(false);
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log("vertical input: " + moveVertical);

        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //Animacion de saltar
            onGround = false;
            onAir = true;
            jumping = true;
            anim.SetTrigger("isJumping");
            
        }
        if (onAir && onGround == false)
        {
            anim.SetTrigger("isFallin");
        }
        
        else if(moveHorizontal != 0 && onGround && onAir == false)
        {
            anim.SetTrigger("isRunning");
        }
        else if(moveHorizontal == 0 && onGround && onAir == false)
        {
            anim.SetTrigger("idle");
        }

        if(moveHorizontal < 0 && facingRight) //Se mueve para la izquierda
        {
            
            Flip();
        }
        if(moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigid.AddForce(movement * maxSpeed);
            
        

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            onGround = true;
            onAir = false;
            jumping = false;
            
            
        }

        if(collision.gameObject.tag == "Fall")
        {
            diePanel.SetActive(true);
        }
          
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground" && jumping == false)
        {
            onGround = false;
            onAir = true;
            jumping = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
