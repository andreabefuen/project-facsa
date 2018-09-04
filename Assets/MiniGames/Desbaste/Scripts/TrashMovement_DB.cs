using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement_DB : MonoBehaviour {

    private Rigidbody2D rBody;
    public float speed = 2f;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        //Si sale de la pantalla
        if (transform.position.x > 10) {
            Manager_DB.timer -= 10;
            Destroy(gameObject);
        }

    }
}
