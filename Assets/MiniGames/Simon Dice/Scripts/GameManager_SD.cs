using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager_SD : MonoBehaviour
{

    public GameObject gameButtonPrefab;
    public GameObject Instructions;

    public List<ButtonSetting_SD> buttonSettings;

    public Transform gameFieldPanelTransform;
    public GameObject GameOverPanel;
    List<GameObject> gameButtons;
    public Text ScoreText;
    int level = 1;
    int bleepCount = 3;
    int score;
    List<int> bleeps;
    List<int> playerBleeps;
    int randomNum;
    System.Random rg;

    bool inputEnabled = false;
    bool gameOver = false;

    void Start()
    {
        score = 0;
        gameButtons = new List<GameObject>();
        randomNum = UnityEngine.Random.Range(0,100);
        CreateGameButton(0, new Vector3(-64, 64));
        CreateGameButton(1, new Vector3(64, 64));
        CreateGameButton(2, new Vector3(-64, -64));
        CreateGameButton(3, new Vector3(64, -64));
        ScoreText.text = "Puntuació: " + score.ToString("00000");
    }

    void CreateGameButton(int index, Vector3 position)
    {
        GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;
        gameButton.transform.localScale = new Vector3(1,1,1);
        gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
        gameButton.GetComponent<Button>().onClick.AddListener(() => {
            OnGameButtonClick(index);
        });

        gameButtons.Add(gameButton);
    }
    public void StartGame()
    {
        Instructions.SetActive(false);
        StartCoroutine(SimonSays());

    }
    void PlayAudio(int index)
    {
        //Debug.Log(index);
        float length = 0.5f;
        float frequency = 0.0005f * ((float)index + 2f);

        AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
        AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));

        LeanAudioOptions audioOptions = LeanAudio.options();
        audioOptions.setWaveSine();
        audioOptions.setFrequency(44100);

        AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);

        LeanAudio.play(audioClip, 0.5f);
    }

    void OnGameButtonClick(int index)
    {
        if (!inputEnabled)
        {
            return;
        }

        Bleep(index);

        playerBleeps.Add(index);

        if (bleeps[playerBleeps.Count - 1] != index)
        {
            GameOver();
            return;
        }

        if (bleeps.Count == playerBleeps.Count)
        {
            score += 50 * (bleepCount-1);
            ScoreText.text = "Puntuació: " + score.ToString("00000");
            if (level == 1 && bleepCount == 10)
            {
                level = 2;
                bleepCount = 3;
                newButtons(level);
            }
            else if (level == 2 && bleepCount == 15)
            {
                level = 3;
                bleepCount = 3;
                newButtons(level);
            }
            StartCoroutine(SimonSays());
        }
    }
    void newButtons(int level)
    {
        if(level == 2)
        {
            randomNum = UnityEngine.Random.Range(0, 100);
            CreateGameButton(4, new Vector3(-192, 64));
            CreateGameButton(5, new Vector3(-192, -64));
        }
        else if(level == 3)
        {
            randomNum = UnityEngine.Random.Range(0, 100);
            CreateGameButton(6, new Vector3(192, 64));
            CreateGameButton(7, new Vector3(192, -64));
        }
    }
    void GameOver()
    {
        gameOver = true;
        inputEnabled = false;
        GameOverPanel.SetActive(true);
    }

    IEnumerator SimonSays()
    {
        inputEnabled = false;

        rg = new System.Random(randomNum.GetHashCode());

        SetBleeps();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < bleeps.Count; i++)
        {
            Bleep(bleeps[i]);

            yield return new WaitForSeconds(0.6f);
        }

        inputEnabled = true;

        yield return null;
    }

    void Bleep(int index)
    {
        LeanTween.value(gameButtons[index], buttonSettings[index].normalColor, buttonSettings[index].highlightColor, 0.25f).setOnUpdate((Color color) => {
            gameButtons[index].GetComponent<Image>().color = color;
        });

        LeanTween.value(gameButtons[index], buttonSettings[index].highlightColor, buttonSettings[index].normalColor, 0.25f)
            .setDelay(0.5f)
            .setOnUpdate((Color color) => {
                gameButtons[index].GetComponent<Image>().color = color;
            });

        PlayAudio(index);
    }

    void SetBleeps()
    {
        bleeps = new List<int>();
        playerBleeps = new List<int>();

        for (int i = 0; i < bleepCount; i++)
        {
            bleeps.Add(rg.Next(0, gameButtons.Count));
        }

        bleepCount++;
    }
}
