using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConstruir : MonoBehaviour {


    BuildManager buildManager;

    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;
    }


    private bool cameraActivate = true;
    private bool demolitionActivate = false;

    public bool GetCameraActivate()
    {
        return cameraActivate;
    }

    public bool GetDemolitionActivate()
    {
        return demolitionActivate;
    }

    public void SetDemolitionActivate(bool activation)
    {
        demolitionActivate = activation;
    }

    public void MoveCamera()
    {
        cameraActivate = !cameraActivate;
    }

    public void Demolition()
    {
        demolitionActivate = !demolitionActivate;
    }
}
