using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove_ER : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode Jump;
    public float speed = 4;
    float horizVel = 0f;
    int laneNum = 2;
    public Text NewRecord;
    public bool controlLock = false;
    public bool OnTheGround = true;

    //score
    public int score = 0;

    public Text ScoreText;
    public GameObject GameOverObject;
    public GameObject Music;
    AudioSource musicAudiosource;
    public AudioClip Explosion;
    // Use this for initialization
    void Start () {
        musicAudiosource = Music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Manager_ER.InGame)
        {//si llega al carril indicado se para
            GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GetComponent<Rigidbody>().velocity.y, speed);
            if (horizVel == -3f && transform.position.x <= -0.9 && laneNum == 1)
            {
                horizVel = 0f;

            }
            else if (horizVel == 3f && transform.position.x >= 0.9 && laneNum == 3)
            {
                horizVel = 0f;

            }
            else if (horizVel == -3f && transform.position.x <= 0.1 && laneNum == 2)
            {
                horizVel = 0f;

            }
            else if (horizVel == 3f && transform.position.x >= -0.1 && laneNum == 2)
            {
                horizVel = 0f;

            }
        }
    }
    void Update () {
        if (Manager_ER.InGame)
        {
            ScoreText.text = "Puntuación: " + score.ToString("00000");
            if (transform.position.y < -1)
            {//si cae gameOver
                GameOver();
            }//comprueba movimiento
            if (Input.GetKeyDown(moveL) && transform.position.x > -1 && !controlLock && laneNum > 1)
            {

                horizVel = -3f;
                laneNum--;
                StartCoroutine(stopSlide());
                controlLock = true;
            }


            if (Input.GetKeyDown(moveR) && transform.position.x < 1 && !controlLock && laneNum < 3)
            {
                horizVel = 3f;
                laneNum++;
                controlLock = true;
                StartCoroutine(stopSlide());


            }
            //comprueba si puede saltar
            if (Input.GetKeyDown(Jump) && OnTheGround)
            {
                OnTheGround = false;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 600, 0));
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {//si toca un obstaculo gameover, capsula suma puntos y si toca el suelo puede volver a saltar
        if(collision.gameObject.tag == "Lethal")
        {
            GameOver();
        }
        if (collision.gameObject.tag == "Capsule")
        {
            GetComponent<AudioSource>().Play();
            score += 100;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            OnTheGround = true;
        }
    }
    IEnumerator stopSlide()
    {//bloquea el movimiento hasta que llega al carril
        yield return new WaitForSeconds(0.32f);
        controlLock = false;
    }
    void GameOver() {

        //Gameover pasa el score a la otra escena
        if (ScoreManager_MM.ERScore < score)
        {
            ScoreManager_MM.ERScore = score;
            NewRecord.text = "Nuevo Record: " + score;
        }

        musicAudiosource.loop = false;
        musicAudiosource.Stop();
        musicAudiosource.clip = Explosion;
        musicAudiosource.Play();
        GameOverObject.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<MoveCamera_ER>().enabled = false;
        Destroy(GameObject.Find("Spawner"));

        Destroy(gameObject);

    }
}
