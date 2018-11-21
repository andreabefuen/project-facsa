using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioManager : MonoBehaviour {

    public GameObject facsa, uji, encolaboracion;

    private Animator facsaAnim, ujiAnim, encolAnim;

    private void Awake()
    {
        facsaAnim = facsa.gameObject.GetComponent<Animator>();
        ujiAnim = uji.gameObject.GetComponent<Animator>();
        encolAnim = encolaboracion.gameObject.GetComponent<Animator>();
        facsa.SetActive(false);
        uji.SetActive(false);
        encolaboracion.SetActive(false);



    }

    private void Start()
    {

        Invoke("StartFacsa", 0.5f);
        Invoke("EnColaboracionStart", 5f);
        Invoke("UjiStart", 8f);
        
    }

    // Use this for initialization
    void StartFacsa () {

        facsa.SetActive(true);


	}

    void UjiStart()
    {

        facsa.SetActive(false);
        encolaboracion.SetActive(false);
        uji.SetActive(true);

        
    }
    void EnColaboracionStart()
    {
        facsa.SetActive(false);
        uji.SetActive(false);
        encolaboracion.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
