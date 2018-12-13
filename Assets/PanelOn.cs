using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOn : MonoBehaviour {

    public GameObject panelWater;
    public GameObject generalPanel;

    public void OnButtonPulseWater()
    {
        panelWater.SetActive(true);
        generalPanel.SetActive(false);
        
    }

    public void OnBackButton()
    {
        panelWater.SetActive(false);
        generalPanel.SetActive(true);
    }
}
