using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour {

    public int lifes;

    public TextMeshProUGUI text;

    public GameObject DiePanel;



    private void Awake()
    {
        text = text.GetComponent<TextMeshProUGUI>();
        text.text = "LIVES: " + lifes.ToString();
    }

    public int GetLifes()
    {
        return lifes;
    }

    public void SetLifes(int l)
    {
        lifes = l;
        text.text = "LIVES: " + lifes.ToString();
        if(lifes <= 0)
        {
            DiePanel.SetActive(true);
           
            Invoke("RestartScene", 3f);
            lifes = 0;
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
