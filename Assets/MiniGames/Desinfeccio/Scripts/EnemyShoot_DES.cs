using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot_DES : MonoBehaviour {

    public float MaxLifeTime = 3f;   // The time in seconds before the shell is removed.
    public float speed = -4f;                    // The time in seconds before the shell is removed.
    private Rigidbody2D rBody;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rBody = GetComponent<Rigidbody2D>();
        Manager_DES.EnemyBullets += 1;
    }

    private void Update()
    {
        //Use the two store floats to create a new Vector2 variable movement.
		transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Manager_DES.Vides > 0){
                Manager_DES.Vides -= 1;
                Manager_DES.EnemyBullets -= 1;
            }
            else
            {
                Manager_DES.Vides -= 1;
                Manager_DES.EnemyBullets -= 1;
                Destroy(collision.gameObject);
            }
            CapsuleCollider2D tCollider;
            tCollider = GetComponent<CapsuleCollider2D>();
            tCollider.enabled = false;
            SpriteRenderer sprite;
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            audioSource.Play();

            Destroy(gameObject, 4f);
        }else if(collision.gameObject.tag == "Water")
        {
            if (Manager_DES.Contaminacio > 0)
            {
                Manager_DES.Contaminacio -= 1;
            }
            Manager_DES.EnemyBullets -= 1;
            Destroy(gameObject);

        }
    }
	IEnumerator  Destroyed(){		
		yield return new WaitForSeconds(MaxLifeTime);

        Manager_DES.EnemyBullets -= 1;
		Destroy(gameObject);
	}
}
