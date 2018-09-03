using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than a one BuildManager in scene!");
            return;
        }
        instance = this;

     
        
    }

    public GameObject standardEdificationPrefab;

    private GameObject structureToBuild; 

    public GameObject GetStructureToBuild()
    {
        return structureToBuild;
    }

	// Use this for initialization
	void Start () {
        
        structureToBuild = standardEdificationPrefab;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
