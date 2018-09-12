using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower_PLA : MonoBehaviour {

    public GameObject towerPrefab;
    private GameObject tower;
    private GameManagerBehavior_PLA gameManager;
    AudioSource SoundPlace;

    // Use this for initialization
    void Start () {
        SoundPlace = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior_PLA>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData_PLA>().levels[0].cost;
        return tower == null && gameManager.Gold >= cost;
    }
    void OnMouseUp()
    {
        //2
        if (gameManager.InGame)
        {
            if (CanPlaceTower())
            {
                //3
                tower = (GameObject)
                  Instantiate(towerPrefab, transform.position, Quaternion.identity);
                //4
                SoundPlace.Play();

                gameManager.Gold -= tower.GetComponent<TowerData_PLA>().CurrentLevel.cost;
            }
            else if (CanUpgradeTower())
            {
                SoundPlace.Play();
                tower.GetComponent<TowerData_PLA>().IncreaseLevel();
                gameManager.Gold -= tower.GetComponent<TowerData_PLA>().CurrentLevel.cost;
            }
        }
    }
    private bool CanUpgradeTower()
    {
        if (tower != null)
        {
            TowerData_PLA towerData = tower.GetComponent<TowerData_PLA>();
            TowerLevel_PLA nextLevel = towerData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }
        }
        return false;
    }

}
