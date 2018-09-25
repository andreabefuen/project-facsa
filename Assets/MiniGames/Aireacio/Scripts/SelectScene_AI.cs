using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene_AI : MonoBehaviour {
    //funcion para cargar escenas
    public void SelectMiniGame(string scene)
    {
        SceneManager.LoadScene(scene); // loads current scene
    }
}
