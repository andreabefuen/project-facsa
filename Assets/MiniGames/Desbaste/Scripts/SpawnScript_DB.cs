using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript_DB : MonoBehaviour {

    public GameObject[] Objects;
    public int timeRespawn;
    public float speed;


    // Use this for initialization
    private void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update () {
        //si el tiempo llega a 0 instancia un objeto con la velocidad marcada random en la posicion del spawner y reinicia el tiempo segun la velocidad sino resta tiempo
        if (timeRespawn <= 0)
        {
            int Rdn = UnityEngine.Random.Range(0, Objects.Length);
            GameObject newObject = Instantiate(Objects[Rdn], transform.position, transform.rotation);
            TrashMovement_DB movement = newObject.GetComponent<TrashMovement_DB>();
            movement.speed = speed;
            timeRespawn = UnityEngine.Random.Range((int)(180/(speed/2)), (int)(300 / (speed / 2)));
        }
        else {
            timeRespawn -= 1;
        }
    }
}
