using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesBoss_DES : MonoBehaviour
{//variación de Enemy2Spawn para la fase de jefe
    int moveCount;
    public bool orientacion;
    public GameObject enemy2;
    int spawnTime;
    public Transform target;//set target from inspector instead of looking in Update

    // Use this for initialization
    void Start() {
        spawnTime = 60;
        moveCount = 4;
        orientacion = true;
        transform.position = new Vector3(-4.0f, transform.position.y, 0.0f);
        target = GameObject.Find("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (spawnTime == 0)
        {
            GameObject instanciado = Instantiate(enemy2, transform.position, transform.rotation);
            instanciado.transform.LookAt(target.position);
            instanciado.transform.Rotate(new Vector3(0, -90, -90), Space.Self);//correcting the original rotation
            spawnTime = 30;
        }else{
            spawnTime -= 1;
        }
        

    }
    private void Move()
    {
        if (moveCount > 0)
        {
            if (orientacion)
            {
                transform.Translate(new Vector3(2, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(-2, 0, 0));
            }
            moveCount -= 1;
        }
        else
        {
            orientacion = !orientacion;
            moveCount = 4;
        }
    }
    
}
