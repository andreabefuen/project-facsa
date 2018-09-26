using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSceneScript_DD : MonoBehaviour
{

    public void RestartGame()
    {//Carga la misma scena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void SelectMiniGame(string scene)
    {//carga la escena indicada
        SceneManager.LoadScene(scene); // loads current scene
    }

}