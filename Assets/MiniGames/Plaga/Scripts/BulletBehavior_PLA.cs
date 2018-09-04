using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior_PLA : MonoBehaviour {

    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    GameObject spawner;
    SpawnEnemy_PLA SpawnerScript;

    private float distance;
    private float startTime;

    private GameManagerBehavior_PLA gameManager;

    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("Road");
        SpawnerScript = spawner.GetComponent<SpawnEnemy_PLA>();
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior_PLA>();

    }

    // Update is called once per frame
    void Update () {
        // 1 
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // 2 
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                // 3
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar_PLA healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar_PLA>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                // 4
                if (healthBar.currentHealth <= 0)
                {
                    SpawnerScript.EnemiesKilled = SpawnerScript.EnemiesKilled + 1;

                    Destroy(target);
                    //AudioSource audioSource = target.GetComponent<AudioSource>();
                    //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                    gameManager.Score += 100;
                    gameManager.Gold += 25;
                }
            }
            Destroy(gameObject);
        }
    }
}
