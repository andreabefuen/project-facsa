using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int damage;
    public TextMeshProUGUI textLives;


	// Use this for initialization
	void Start () {
        
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CharacterStats.lifes-= damage;
            textLives.SetText("LIVES: " + CharacterStats.lifes);
        }
    }
}
