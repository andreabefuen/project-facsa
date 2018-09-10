using UnityEngine;
using System.Collections;


public class Ball_FA : MonoBehaviour
{

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Rigidbody2D rBody2D;
    public float speed = 6.0f;
    AudioSource audioSource;
    public AudioClip boom;
    public AudioClip plop;

    // GameObject
    public GameObject playerObject;

    // Use this for initialization
    void Start()
    {

        // create the force
        Vector3 direction = new Vector3(1, 1, 0).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        audioSource = gameObject.GetComponent<AudioSource>();
        // set to inactive
        ballIsActive = false;

        // ball position
        ballPosition = transform.position;

        rBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // check for user input
        if (Input.GetButtonDown("BallFA") == true)
        {
            // check if is the first play
            if (!ballIsActive && Manager_FA.InGame)
            {
                audioSource.clip = plop;

                Manager_FA.BallInGame = true;
                // reset the force
                rBody2D.isKinematic = false;


                // add a force
                Vector3 direction = new Vector3(1, 1, 0).normalized;
                GetComponent<Rigidbody2D>().velocity = direction * speed;

                // set ball active
                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive && playerObject != null)
        {

            // get and use the player position
            ballPosition.x = playerObject.transform.position.x;

            // apply player X position to the ball
            transform.position = ballPosition;
        }

        // Check if ball falls
        if (ballIsActive && transform.position.y < -6)
        {
            audioSource.clip = boom;
            audioSource.Play();
            Manager_FA.Vides -= 1;
            Manager_FA.BallInGame = false;
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -3.8f;
            transform.position = ballPosition;
            rBody2D.isKinematic = true;
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?

        if (col.gameObject.name == "Player")
        {
            audioSource.Play();
            // Calculate hit Factor
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}