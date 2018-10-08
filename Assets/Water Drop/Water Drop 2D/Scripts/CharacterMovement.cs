using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    public int jumpForce;

    public Slider waterSlider;
    public int damageForGround;
    public int lifeForWater;

    private Rigidbody2D rigid;
    private bool onGround = true;

    private bool notSwimming = false;

    private Animator anim;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D>();
        waterSlider.value = 100;

        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");


        if(anim.GetBool("isSwimming") == true)
        {
            if ((moveHorizontal < 0 && facingRight) || (moveHorizontal > 0 && !facingRight))
            {

                FlipSwimming();
            }
        }
        
        else 
        {
            

            if ((moveHorizontal < 0 && facingRight) || (moveHorizontal > 0 && !facingRight))
            {

                Flip();
            }
        }

       //if ((moveHorizontal <0 && facingRight) || (moveHorizontal >0 && !facingRight))
       //{
       //
       //    FlipSwimming();
       //}

        if (Input.GetKeyDown("space") && onGround)
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            onGround = false;
        }

      

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

       

        rigid.AddForce(movement * maxSpeed );

        if(waterSlider.value == 0)
        {
            GameOver();
        }
        
		
	}  


    void FlipSwimming()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "Water")
        {
            onGround = true;
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            waterSlider.value -= damageForGround * Time.deltaTime;
            anim.SetBool("isSwimming", false);
            this.transform.rotation = Quaternion.identity;
        }

        if(collision.gameObject.tag == "Water")
        {
            
            anim.SetBool("isSwimming", true);
            waterSlider.value += lifeForWater * Time.deltaTime;
            
        }
    }

    void GameOver()
    {
        Debug.Log("HAS MUERTO");
    }
}
