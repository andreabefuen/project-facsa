using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

    int Points = 1;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	public void  SetPoints(int p) {
        Points = p;

        transform.localScale += new Vector3(1 + (0.1f * p), 0f, 1 + (0.1f * p));

    }
    public int GetPoints()
    {
        return Points;
    }
}
