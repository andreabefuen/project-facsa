﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSceneScript_FIL : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void SelectMiniGame(string scene)
    {
        SceneManager.LoadScene(scene); // loads selected scene
    }

}