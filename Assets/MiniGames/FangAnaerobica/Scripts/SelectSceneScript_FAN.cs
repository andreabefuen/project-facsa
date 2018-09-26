using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSceneScript_FAN : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void SelectMiniGame(string scene)
    {
        SceneManager.LoadScene(scene); // loads indicate scene
    }

}