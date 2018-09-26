using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFood_IO : MonoBehaviour {

    public List<GameObject> FoodInRange;
    public Transform Enemy;

    // Use this for initialization
    private void Update()
    {
        this.transform.position = Enemy.position;
    }
    private void OnTriggerEnter(Collider other)
    {//si entra comida la guarda en la lista
        if(other.gameObject.tag == "Food")
        {
            FoodInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {//si sale la comida la borra de la lista
        if (other.gameObject.tag == "Food")
        {
            FoodInRange.Remove(other.gameObject);
        }
    }
    public GameObject SearchClosest()
    {
        float minDist = 10000;
        GameObject Closest = null;
        if (FoodInRange.Count > 0)
        {
            for (int i = 0; i< FoodInRange.Count; i++)
            {
                if (FoodInRange[i] == null)
                {//si esta null lo elimina de la lista
                    FoodInRange.RemoveAt(i);
                }else
                {//calcula la distancia y si es menor la guarda
                    float dist = Mathf.Abs(Vector2.Distance(this.transform.position, FoodInRange[i].transform.position));
                    if (dist < minDist)
                    {
                        minDist = dist;
                        Closest = FoodInRange[i];
                    }
                }
            }
        }//devuelve el objeto con minDistancia(mas cercano)
        return Closest;
    }

}
