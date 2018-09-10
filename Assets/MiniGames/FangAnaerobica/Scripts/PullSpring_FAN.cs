using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullSpring_FAN : MonoBehaviour {

    public string inputButtonName = "PullFangAnaerobica";
    public float distance = 50;
    public float speed = 1;
    public GameObject ball;
    public float power = 2000;
    bool ready = false;
    bool fire = false;
    float moveCount = 0;
    public AudioSource Sound;
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(inputButtonName) && ManagerScript_FAN.InGame)
        {
            //As the button is held down, slowly move the piece
            if (moveCount < distance)
            {
                transform.Translate(0, 0, -speed * Time.deltaTime);
                moveCount += speed * Time.deltaTime;
                fire = true;
            }
        }
        else if (moveCount > 0)
        {
            //Shoot the ball
            if (fire && ready)
            {
                ball.transform.TransformDirection(Vector3.forward * 10);
                ball.GetComponent<Rigidbody>().AddForce(0, 0, moveCount * power);
                fire = false;
                ready = false;
                Sound.Play();
            }
            //Once we have reached the starting position fire off!
            transform.Translate(0, 0, 20 * Time.deltaTime);
            moveCount -= 20 * Time.deltaTime;
        }

        //Just ensure we don't go past the end
        if (moveCount <= 0)
        {
            fire = false;
            moveCount = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ready = true;
        }
    }
}
