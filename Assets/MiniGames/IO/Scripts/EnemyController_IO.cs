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
        Points = player.GetComponent<MovingPlayer_IO>().Points;
    }

    // Update is called once per frame
    void Update () {
        if (ToPlayer)
        {
            if(this.transform.localScale.x > player.transform.localScale.x + 0.4)
            {
                speed = 3f;
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
        {
            ToPlayer = true;
        }
        else if (food == null)
        {
            food = Searcher.SearchClosest();
        }
        else
        {
            speed = 3f;
            transform.LookAt(food.transform.position);
            transform.Rotate(new Vector3(90, 0, 0), Space.Self);//correcting the original rotation
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
