using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScript_AI : MonoBehaviour
{
    //recarga la escena actual
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}