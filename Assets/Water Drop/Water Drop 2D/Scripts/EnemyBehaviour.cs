using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int damage;
   
    public CharacterStats characterStats;


	// Use this for initialization
	void Start () {
        characterStats = characterStats.GetComponent<CharacterStats>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Debug.Log("DAÑO");
           // Debug.Log(characterStats.GetLifes());
            characterStats.SetLifes(characterStats.GetLifes()- damage);
            Debug.Log("Lifes: " + characterStats.lifes);
            //textLives.SetText("LIVES: " + CharacterStats.lifes);
        }
    }
}
