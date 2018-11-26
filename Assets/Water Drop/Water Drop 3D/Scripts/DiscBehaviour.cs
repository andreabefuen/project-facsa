using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscBehaviour : MonoBehaviour {

    public float speed;

    Transform[] parts;

    Transform start;
    
    float multiplier;

	// Use this for initialization
	void Start () {

        parts = this.GetComponentsInChildren<Transform>();

        multiplier = Random.Range(-1f, 1f);

        this.transform.rotation = Quaternion.Euler(0, 90, 0);
        start = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if(transform.position.x > 230)
        {
            Destroy(this.gameObject);
        }

        for (int i = 0; i < parts.Length; i++)
        {
            if(i%2 == 0)
            {
                
                parts[i].rotation = Quaternion.Euler((Vector3.forward * Mathf.Sin(Time.time * multiplier / Time.timeScale) * 360).x, 90, (Vector3.forward * Mathf.Sin(Time.time * multiplier / Time.timeScale) * 360).z);
            }
            else
            {
                
                parts[i].rotation = Quaternion.Euler((Vector3.forward * Mathf.Cos(Time.time / Time.timeScale) * 360).x, 90, (Vector3.forward * Mathf.Cos(Time.time / Time.timeScale) * 360).z);
            }
        }
	}
}
