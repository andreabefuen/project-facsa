using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement3D : MonoBehaviour {

    public float velocityX;
    public float jumpingForce;
    public int lifes;

    public GameObject dieCanvas;
    public Text lifesText;

    public GameObject escenario;

    private Rigidbody rigid;
    private Vector3 movement;
    private Vector3 rightMove;
    private Vector3 leftMove;

    private Vector3 initalPos;


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

        initalPos = transform.position;

        lifesText.text = "LIVES: " + lifes;

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
    void DecreaseLifes()
    {
        lifes--;
        UpdateLifeText();
        if (lifes == 0)
        {
            YouDie();
        }
    }
    void YouDie()
    {
        dieCanvas.SetActive(true);
        escenario.SetActive(false);
        Time.timeScale = 0;
    }
    void UpdateLifeText()
    {
        lifesText.text = "LIVES: " + lifes;
    }

    public void RestartPosition()
    {
        Time.timeScale = 1;
        dieCanvas.SetActive(false);
        escenario.SetActive(true);
        transform.position = initalPos;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Te quita vida");
            DecreaseLifes();
            

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HAS MUERTO 2");

            //Invoke("RestartPosition", 3f);
            YouDie();
            

        }
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("Pasamos al siguiente nivel");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isJumpingPossible = true;
            //Debug.Log("is possible yes");
        }
    }


}
