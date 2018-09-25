using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer_IO : MonoBehaviour
{


    public float speed = 5f;
    public int MaxDist = 250;
    public GameObject Camara;
    Vector3 movement;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    //score--------------------------
    public int Points;

    public bool StartGame;
    public AudioClip EatEnemy;
    public AudioClip EatFood;
    AudioSource Sound;
    // Use this for initialization
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        StartGame = false;
        Sound = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (StartGame)
        {
            Move();
        }
    }
    void Move()
    {

        if (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width && Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height - 1)
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;
                float dist = Mathf.Abs(Vector2.Distance(Input.mousePosition, new Vector2(Screen.width / 2, Screen.height / 2)));
                if (dist > MaxDist) dist = MaxDist;
                speed = Mathf.Lerp(0, 5, dist / MaxDist);

                // Set the player's rotation to this new rotation.
                movement.Set(playerToMouse.x, playerToMouse.y, playerToMouse.z);

                // Normalise the movement vector and make it proportional to the speed per second.
                movement = movement.normalized * speed * Time.deltaTime;

                // Move the player to it's current position plus the movement.
                playerRigidbody.MovePosition(transform.position + movement);
            }
        }
        else
        {
            movement.Set(0f, 0f, 0f);

            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movement);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food" && other.transform.localScale.x < this.transform.localScale.x)
        {
            Points += other.GetComponent<FoodScript_IO>().Points;
            Sound.clip = EatFood;
            Sound.Play();
            Destroy(other.gameObject);
            this.transform.localScale = new Vector3(4 + 0.2f * (Points / 20), 4 + 0.2f *( Points / 20), 1);
            Camara.GetComponent<Camera>().orthographicSize = 5 + 0.3f * (Points/20);
            
        }
        if (other.tag == "Enemy" && other.transform.localScale.x < this.transform.localScale.x)
        {
            Points += other.GetComponent<EnemyController_IO>().Points;
            Sound.clip = EatEnemy;
            Sound.Play();
            Destroy(other.gameObject);
            this.transform.localScale = new Vector3(4 + 0.2f * (Points / 20), 4 + 0.2f * (Points / 20), 1);
            Camara.GetComponent<Camera>().orthographicSize = 5 + 0.3f * (Points / 20);
        }

    }
}

