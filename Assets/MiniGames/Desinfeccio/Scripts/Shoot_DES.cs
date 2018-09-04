using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_DES : MonoBehaviour {

    
    public float MaxLifeTime = 3f;   // The time in seconds before the shell is removed.
    public float speed = 4f;                    // The time in seconds before the shell is removed.
    private Rigidbody2D rBody;
    private Vector2 velocity;


    private void Start()
    {
        // If it isn't destroyed by then, destroy the shell after it's lifetime.
        Destroy(gameObject, MaxLifeTime);
        rBody = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0f, speed);
    }

    private void Update()
    {

        //Use the two store floats to create a new Vector2 variable movement.
        rBody.velocity = velocity;

    }
    void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Enemy") {
            collision.GetComponent<EnemyController_DES>().Destruido();
            Destroy(gameObject);
        } else if (collision.tag == "Enemy2") {
            collision.GetComponent<EnemyController2_DES>().Destruido();
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Boss"){
            if (Manager_DES.BossLive <= 1)
            {
                collision.GetComponent<BossController_DES>().Destruido();
                Destroy(gameObject);
            }
            else
            {
                if (!collision.GetComponent<BossController_DES>().intermedio)
                {
                    Manager_DES.BossLive -= 1;
                    Destroy(gameObject);
                    Manager_DES.Score += 50;
                }
            }
		}
    }
}
