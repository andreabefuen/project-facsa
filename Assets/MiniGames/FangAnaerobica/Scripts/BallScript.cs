using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public float explosionStrength = 1500;
    AudioSource Sounds;
    bool BallType;
    Renderer rend;
    AudioSource Sound;
    public AudioClip Bell;
    public AudioClip Fail;
    // Use this for initialization
    void Start () {
        BallType = true;
        Sound = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", new Color(0,255,0,255));
        Sounds = gameObject.GetComponent<AudioSource>();

	}
    private void Update()
    {
        if (Input.GetButtonDown("BallType"))
            ChangeBall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bactery")
        {
            if (collision.gameObject.name == "GoodBactery(Clone)")
            {
                if (BallType)
                {
                    ManagerScript.Score += 150;
                    Sound.clip = Bell;
                    Sound.Play();
                }
                else {
                    ManagerScript.Score -= 100;
                    Sound.clip = Fail;
                    Sound.Play();
                }
                this.GetComponent<Rigidbody>().AddExplosionForce(explosionStrength, collision.transform.position, 5);
                Destroy(collision.gameObject);
                ManagerScript.NumBacteries -= 1;
            }
            if (collision.gameObject.name == "BadBactery(Clone)")
            {
                if (BallType)
                {
                    ManagerScript.Score -= 100;
                    Sound.clip = Fail;
                    Sound.Play();
                }
                else
                {
                    ManagerScript.Score += 150;
                    Sound.clip = Bell;
                    Sound.Play();
                }
                this.GetComponent<Rigidbody>().AddExplosionForce(explosionStrength, collision.transform.position, 5);
                Destroy(collision.gameObject);
                ManagerScript.NumBacteries -= 1;
            }
        }
    }
    void ChangeBall()
    {
        if (BallType)
        {
            BallType = false;
            rend.material.SetColor("_Color", new Color(255, 0, 0, 255));
        }
        else
        {
            BallType = true;
            rend.material.SetColor("_Color", new Color(0, 255, 0, 255));
        }
    }
}
