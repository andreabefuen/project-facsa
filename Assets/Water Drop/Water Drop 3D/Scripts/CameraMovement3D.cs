using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement3D : MonoBehaviour {

    public float velocityX;
    public float jumpingForce;

    private Rigidbody rigid;
    private Vector3 movement;
    private Vector3 rightMove;
    private Vector3 leftMove;

    private bool isKeyPressed = false;
    private bool isJumpingPossible = true;

	// Use this for initialization
	void Start () {

        velocityX *= -1;
        rigid = GetComponent<Rigidbody>();

        rigid.velocity = new Vector3(velocityX, 0, 0);

        movement = new Vector3(1, 0, 0);
        rightMove = new Vector3(0, 0, -1);
        leftMove = new Vector3(0, 0, 1);


    }
	
	// Update is called once per frame
	void Update () {
        rigid.MovePosition(transform.position +  movement * velocityX * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isJumpingPossible == true)
        {
            rigid.AddForce(new Vector3(0, jumpingForce, 0), ForceMode.Impulse);
            isJumpingPossible = false;

        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigid.MovePosition(transform.position + rightMove * velocityX * Time.deltaTime + movement * velocityX * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.MovePosition(transform.position + leftMove * velocityX * Time.deltaTime + movement * velocityX * Time.deltaTime);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isJumpingPossible = true;
        }
    }
}
