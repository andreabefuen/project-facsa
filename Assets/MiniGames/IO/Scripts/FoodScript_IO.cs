using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript_IO : MonoBehaviour
{

    public int Points = 1;
    public GameObject spawner;
    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        float rdmR = Random.Range(0, 255f);
        float rdmG = UnityEngine.Random.Range(0, 255);
        float rdmB = UnityEngine.Random.Range(0, 255);
        GetComponent<SpriteRenderer>().color = new Color(rdmR/255, rdmG/255, rdmB/255);
    }

    // Update is called once per frame
    public void SetPoints(int p)
    {//escala segun su puntuacion
        Points = p;

        transform.localScale += new Vector3(1 + (0.1f * p), 0f, 1 + (0.1f * p));

    }
     public int GetPoints()
     {
         return Points;
     }
    private void OnDestroy()
    {
        spawner.GetComponent<FoodSpawner_IO>().FoodInScene--;
    }
}
