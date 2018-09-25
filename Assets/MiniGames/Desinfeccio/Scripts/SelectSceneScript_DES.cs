using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSceneScript_DES : MonoBehaviour
{

    public void RestartGame()
    {//recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void SelectMiniGame(string scene)
    {//cambia de escena
        SceneManager.LoadScene(scene); // loads current scene
    }

}