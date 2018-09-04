using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController_DES : MonoBehaviour {

	public GameObject bullet;
    public GameObject Healt;
    public GameObject Lifes;
    public float speed = 2f;
    public int score;
	private bool orientation = true;
    bool changeAction;
    public bool intermedio;
    public Transform target;//set target from inspector instead of looking in Update
	int timeShoot;
	int timeShoot1;
	int timeShoot2;
    int timeWait;
    public GameObject spawner;
    public AudioClip explosionClip;
    AudioSource audioSource;
    bool destroyed;


    void Start()
	{
        target = GameObject.Find("Player").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        score = 2500;
		timeShoot = 300 / Manager_DES.MaxBullets;
		timeShoot1 = 500 / Manager_DES.MaxBullets;
		timeShoot2 = 600 / Manager_DES.MaxBullets;
        changeAction = true;
        Manager_DES.BossLive += 100;
        intermedio = false;
        Manager_DES.EnemiesInScene += 1;
        destroyed = false;
    }
    void Update() {

        if (Manager_DES.BossLive <= 50 && changeAction)
        {
            if (!intermedio)
            {
                Instantiate(Healt, transform.position, transform.rotation);
            }

            intermedio = true;
            Manager_DES.BossLive = 50;
            Vector3 pos = new Vector3(-4f, 7f, 0); ;
            Instantiate(spawner, pos, transform.rotation);
            timeWait = 600;
            changeAction = false;
            Intermedio();
        }
    }

	void FixedUpdate()
	{
        if (!destroyed)
        {
            if (!intermedio)
            {
                Move();

                if (timeShoot <= 0)
                {
                    Shoot(0);
                }
                if (timeShoot1 <= 0)
                {
                    Shoot(1);
                }
                if (timeShoot2 <= 0)
                {
                    Shoot(2);
                }
                timeShoot -= 1;
                timeShoot1 -= 1;
                timeShoot2 -= 1;
            }
            else
            {

                Intermedio();
                Manager_DES.BossLive = 50;
            }
        }
    }
    void Move()
    {
        if (transform.position.y > 3.4f)
            transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
        else if (orientation)
        {
            if (transform.position.x <= 1.5f)
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            else
                orientation = !orientation;
        }
        else
        {
            if (transform.position.x >= -1.5f)
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            else
                orientation = !orientation;
        }

    }
    void Shoot(int cannon)
	{
		if (cannon == 0) {
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y - 0.5f, 0);
			GameObject newBullet = Instantiate (bullet, pos, bullet.transform.rotation);
			newBullet.transform.LookAt (target.position);
			newBullet.transform.Rotate (new Vector3 (0, -90, 90), Space.Self);//correcting the original rotation
			timeShoot = UnityEngine.Random.Range (300 / Manager_DES.MaxBullets, 600 / Manager_DES.MaxBullets);
		}else if (cannon == 1) {
			Vector3 pos = new Vector3 (transform.position.x + 1.7f, transform.position.y - 1.2f, 0);
			GameObject newBullet = Instantiate (bullet, pos, bullet.transform.rotation);
			newBullet.transform.LookAt (target.position);
			newBullet.transform.Rotate (new Vector3 (0, -90, 90), Space.Self);//correcting the original rotation
			timeShoot1 = UnityEngine.Random.Range (400 / Manager_DES.MaxBullets, 700 / Manager_DES.MaxBullets);
		}else if(cannon == 2) {
			Vector3 pos = new Vector3 (transform.position.x + -1.7f, transform.position.y - 1.2f, 0);
			GameObject newBullet = Instantiate (bullet, pos, bullet.transform.rotation);
			newBullet.transform.LookAt (target.position);
			newBullet.transform.Rotate (new Vector3 (0, -90, 90), Space.Self);//correcting the original rotation
			timeShoot2 = UnityEngine.Random.Range (400 / Manager_DES.MaxBullets, 700 / Manager_DES.MaxBullets);
		}
        audioSource.Play();
    }

    void Intermedio() {
        if (transform.position.y <= 7f)
            transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
        else if (transform.position.x != 0f)
            transform.position = new Vector3(0.0f, transform.position.y, 0.0f);
        if (timeWait <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Spawner"));
            Vector3 pos = new Vector3(-4f, 7f, 0); ;
            Instantiate(spawner, pos, transform.rotation);
            intermedio = false;
        }else {
            timeWait -= 1;
        }
    }
    public void Destruido()
    {
        audioSource.clip = explosionClip;
        audioSource.Play();

        Manager_DES.Score += score;
        Manager_DES.EnemiesInScene -= 1;
        if (!destroyed)
        {
            Instantiate(Healt, transform.position, transform.rotation);
            Instantiate(Lifes, transform.position, transform.rotation);
        }
        destroyed = true;
        Destroy(gameObject, 0.4f);
        

    }
}
