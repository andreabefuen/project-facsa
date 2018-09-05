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

    public void PurchaseStandardStructure()
    {
        Debug.Log("Standard Structure Purchased");
        buildManager.SetStructureToBuild(buildManager.standardEdificationPrefab);

    }

    public void PurchaseAnotherStructure()
    {
        Debug.Log("Another structure purchased");
        buildManager.SetStructureToBuild(buildManager.structureFacsa);
    }

    private bool cameraActivate = true;

    public bool GetCameraActivate()
    {
        return cameraActivate;
    }

    public void MoveCamera()
    {
        cameraActivate = !cameraActivate;
    }

    public void Demolition()
    {

    }
}
