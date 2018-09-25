using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_DB : MonoBehaviour {
    Vector3 InitPosition;
    public AudioClip Organic;
    public AudioClip Plastic;
    public AudioClip Cristal;
    public AudioClip Carto;
    public AudioClip Fail;
    public int score = 4;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void OnMouseDown() {
        //guarda posicion inicial
        InitPosition = transform.position;
    }

    private void OnMouseDrag()
    {//mueve con el raton el objeto
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3 (objPosition.x, objPosition.y, -2);
    }
    private void OnMouseUp()
    {//comprueba donde se suelta
        if (transform.position.y < -2)
        {
            //Zona contenedores

            if (transform.position.x > -8.9 && transform.position.x < -4.45)
            {
                //Contenedor Organico
                if (gameObject.tag == "Organic")
                {
                    audioSource.clip = Organic;
                    audioSource.Play();
                    Manager_DB.score += 100;
                    Manager_DB.timer += score;
                }
                else {
                    audioSource.clip = Fail;
                    audioSource.Play();
                    Manager_DB.timer -= score;
                }
            }
            else if (transform.position.x > -4.45 && transform.position.x < 0)
            {
                //Contenedor Carton
                if (gameObject.tag == "Carto")
                {
                    audioSource.clip = Carto;
                    audioSource.Play();
                    Manager_DB.score += 100;
                    Manager_DB.timer += score;
                }
                else
                {
                    audioSource.clip = Fail;
                    audioSource.Play();
                    Manager_DB.timer -= score;
                }
            }
            else if(transform.position.x > 0 && transform.position.x < 4.45)
            {
                //Contenedor Plastico
                if (gameObject.tag == "Plastic")
                {
                    audioSource.clip = Plastic;
                    audioSource.Play();
                    Manager_DB.score += 100;
                    Manager_DB.timer += score;
                }
                else
                {
                    audioSource.clip = Fail;
                    audioSource.Play();
                    Manager_DB.timer -= score;
                }
            }
            else if (transform.position.x > 4.45 && transform.position.x < 8.9)
            {
                //Contenedor Vidrio
                if (gameObject.tag == "Vidre")
                {
                    audioSource.clip = Cristal;
                    audioSource.Play();
                    Manager_DB.score += 100;
                    Manager_DB.timer += score;
                }
                else
                {
                    audioSource.clip = Fail;
                    audioSource.Play();
                    Manager_DB.timer -= score;
                }
            }
            SpriteRenderer sprite;
            sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            Destroy(gameObject,2f);

        }
        else {
            //si nos e suelta en ningun contenedor vuelve a la posicion inicial
            transform.position = InitPosition;
        }

    }
}
