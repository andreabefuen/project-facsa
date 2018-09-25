using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawn_DES : MonoBehaviour {
    //spawnea cada cierto tiempo lso segundos enemigos con direccion el jugador
    int moveCount;
    public bool orientacion;
    public GameObject enemy2;
    int spawnTime;
	public Transform target;//set target from inspector instead of looking in Update

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").GetComponent<Transform>();
        moveCount = 4;
        orientacion = true;
        spawnTime = UnityEngine.Random.Range(400/ Manager_DES.MaxBullets, 600/ Manager_DES.MaxBullets);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveCount > 0)
        {
            if (orientacion) {
                transform.Translate(new Vector3(2, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(-2, 0, 0));
            }
            moveCount -= 1;
        }else {
            orientacion = !orientacion;
            moveCount = 4;
        }
        if (spawnTime == 0)
        {
            GameObject instanciado = Instantiate(enemy2, transform.position, transform.rotation);  
			instanciado.transform.LookAt(target.position);
			instanciado.transform.Rotate(new Vector3(0, -90, -90), Space.Self);//correcting the original rotation
            spawnTime = UnityEngine.Random.Range(400 / Manager_DES.MaxBullets, 600 / Manager_DES.MaxBullets);
        }
        else {
            spawnTime -= 1;
        }

    }
}
