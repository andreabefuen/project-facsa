using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards_OD : MonoBehaviour {

    public GameObject[] Cartes;

	// Use this for initialization
	void Start () {
        int HandCard = 0;
        int rand;
        while(HandCard < Cartes.Length)
        {
            rand = UnityEngine.Random.Range(0, Cartes.Length);
            if(Cartes[rand] != null)
            {
                GameObject newCard = Instantiate(Cartes[rand], transform.position, transform.rotation);
                newCard.transform.SetParent(transform);
                Cartes[rand] = null;
                HandCard += 1;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
