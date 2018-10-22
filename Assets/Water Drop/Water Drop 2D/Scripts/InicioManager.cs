using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioManager : MonoBehaviour {

    public GameObject facsa, uji, encolaboracion;

    private Animation facsaAnim, ujiAnim, encolAnim;

    private void Awake()
    {
        facsaAnim=facsa.gameObject.GetComponent<Animation>();
        ujiAnim = uji.gameObject.GetComponent<Animation>();
        encolAnim = encolaboracion.gameObject.GetComponent<Animation>();

        facsaAnim.Stop();
        ujiAnim.Stop();


    }
    // Use this for initialization
    IEnumerator Start () {


        facsaAnim.Play(facsaAnim.clip.name);
        yield return new WaitForSeconds(facsaAnim.clip.length);

        StartCoroutine(ujiStart());
        
		
	}

    IEnumerator ujiStart()
    {
        ujiAnim.Play(ujiAnim.clip.name);
        yield return new WaitForSeconds(facsaAnim.clip.length);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
