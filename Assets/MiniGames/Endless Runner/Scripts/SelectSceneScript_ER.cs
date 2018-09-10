using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSceneScript_ER : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void SelectMiniGame(string scene)
    {
        SceneManager.LoadScene(scene); // loads current scene
    }

}