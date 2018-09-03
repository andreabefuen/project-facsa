using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float MaxLifeTime = 3f;   // The time in seconds before the shell is removed.
    public float speed = -4f;                    // The time in seconds before the shell is removed.
    private Rigidbody2D rBody;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rBody = GetComponent<Rigidbody2D>();
		Manager.EnemyBullets += 1;
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
            if (Manager.Vides > 0){
                Manager.Vides -= 1;
                Manager.EnemyBullets -= 1;
            }
            else
            {
                Manager.Vides -= 1;
				Manager.EnemyBullets -= 1;
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
            if (Manager.Contaminacio > 0)
            {
                Manager.Contaminacio -= 1;
            }
			Manager.EnemyBullets -= 1;
            Destroy(gameObject);

        }
    }
	IEnumerator  Destroyed(){		
		yield return new WaitForSeconds(MaxLifeTime);

		Manager.EnemyBullets -= 1;
		Destroy(gameObject);
	}
}
