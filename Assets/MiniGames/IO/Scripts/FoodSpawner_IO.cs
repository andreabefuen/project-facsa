using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner_IO : MonoBehaviour {

    public GameObject FoodPrefab;
    public int maxFood = 3000;
    public int FoodInScene;
	// Use this for initialization
	void Start () {
        FoodInScene = 0;

    }

    // Update is called once per frame
    void Update () {
        if(FoodInScene<maxFood)
        {

            Spawn();
            FoodInScene++;
        }
    }

    void Spawn()
    {
        if (FoodInScene > 200)
        {
            int rdmX = UnityEngine.Random.Range(-150, 150);
            int rdmZ = UnityEngine.Random.Range(-150, 150);
            Vector3 pos = new Vector3(rdmX, 0.01f, rdmZ);
            GameObject food = Instantiate(FoodPrefab, pos, FoodPrefab.transform.rotation);
            food.transform.SetParent(this.transform);
            int Points = UnityEngine.Random.Range(1, 6);
            food.transform.localScale += new Vector3(0.3f * Points, 0.3f * Points, 0);
            food.GetComponent<FoodScript_IO>().Points = Points;
        }else
        {
            int rdmX = UnityEngine.Random.Range(-50, 50);
            int rdmZ = UnityEngine.Random.Range(-50, 50);
            Vector3 pos = new Vector3(rdmX, 0.01f, rdmZ);
            GameObject food = Instantiate(FoodPrefab, pos, FoodPrefab.transform.rotation);
            food.transform.SetParent(this.transform);
            int Points = UnityEngine.Random.Range(1, 6);
            food.transform.localScale += new Vector3(0.3f * Points, 0.3f * Points, 0);
            food.GetComponent<FoodScript_IO>().Points = Points;
        }
    }

}
