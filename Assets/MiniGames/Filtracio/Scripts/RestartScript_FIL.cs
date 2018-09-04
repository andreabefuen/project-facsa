using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScript_FIL : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Filtracio2"); // loads current scene
    }


}