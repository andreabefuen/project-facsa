using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestManager : MonoBehaviour {

    public Animator anim;
    public string nameNextLevel;
    public GameObject screenPassLevel;
    public float delay;
   

	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();

        //animation.GetComponent<Animation>();

        //animation.Stop();

        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.enabled = true;
            Time.timeScale = 0;
            screenPassLevel.active = true;
            StartCoroutine(NextLevel(delay));
        }
    }


    IEnumerator NextLevel(float time)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nameNextLevel);
    }


}
