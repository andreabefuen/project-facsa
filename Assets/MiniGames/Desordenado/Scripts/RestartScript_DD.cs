﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScript_DD : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

}