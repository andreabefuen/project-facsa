using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_IO : MonoBehaviour {
    public int Points;
    GameObject player;
    float speed = 3f;
    GameObject food;
    bool ToPlayer;
    public SearchFood_IO Searcher;
    GameObject Manager;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        ToPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player");
        Points = player.GetComponent<MovingPlayer_IO>().Points/2 + 20;
    }

    // Update is called once per frame
    void Update () {
        //define comportamiento del enemigo segun su tamaño
        if (ToPlayer)
        {//si va a por ti y si es poco mas grande volvera a por comida
            if(this.transform.localScale.x > player.transform.localScale.x + 0.4)
            {
                speed = 3.3f;
                transform.LookAt(player.transform.position);
                transform.Rotate(new Vector3(90, 0, 0), Space.Self);//correcting the original rotation
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            else
            {
                ToPlayer = false;
            }
        }
		else if(this.transform.localScale.x > player.transform.localScale.x + 1)
        {//si es mas grande empieza a por ti
            ToPlayer = true;
        }
        else if (food == null)
        {//busca comida cercana
            food = Searcher.SearchClosest();
        }
        else
        {//va a por la comida
            speed = 2.5f;
            transform.LookAt(food.transform.position);
            transform.Rotate(new Vector3(90, 0, 0), Space.Self);//correcting the original rotation
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {//si come comida crece si te come gameover
        if(other.gameObject.tag == "Food")
        {
            Points += other.gameObject.GetComponent<FoodScript_IO>().Points;
            Searcher.FoodInRange.Remove(other.gameObject);
            Destroy(other.gameObject);

            this.transform.localScale = new Vector3(4 + 0.2f * (Points /10), 4 + 0.2f * (Points / 10), 1);
            
        }
        else if(other.gameObject.tag == "Player" && this.transform.localScale.x > player.transform.localScale.x)
        {
            Manager.GetComponent<ManagerScript_IO>().GameOver();
        }
    }
}
