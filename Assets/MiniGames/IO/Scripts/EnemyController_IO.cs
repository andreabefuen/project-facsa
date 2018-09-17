using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_IO : MonoBehaviour {
    Transform player;
    float speed = 2.5f;
    Transform food;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update () {
		if(this.transform.localScale.x > player.localScale.x + 1)
        {
           transform.LookAt(player.position);
            transform.Rotate(new Vector3(90, 0, 0), Space.Self);//correcting the original rotation
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        else if (food == null)
        {
            //food = SearchFood();
        }
    }


}
