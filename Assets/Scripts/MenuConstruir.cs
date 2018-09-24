using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConstruir : MonoBehaviour {


    BuildManager buildManager;

    public GameObject shop;
    public GameObject streetMenu;


    private bool cameraActivate = true;
    private bool demolitionActivate = false;
    private bool shopActivate = false;


    // Use this for initialization
    void Start()
    {
        buildManager = BuildManager.instance;
    }


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

    public void BuyHUD()
    {
        shop.SetActive(!shopActivate);
        shopActivate = !shopActivate;
        streetMenu.SetActive(false);
        
    }
}
