using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mueve a los enemigos entre los waypoints

public class MoveEnemy_PLA : MonoBehaviour {
    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    public GameObject spawner;
    AudioSource damageSound;
    SpawnEnemy_PLA SpawnerScript;
    bool destroyed = false;
    // Use this for initialization
    void Start () {
        damageSound = GetComponent<AudioSource>();
        spawner = GameObject.Find("Road");
        SpawnerScript = spawner.GetComponent<SpawnEnemy_PLA>();
        lastWaypointSwitchTime = Time.time;

    }

    // Update is called once per frame
    void Update () {
        // 1 
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        // 2 
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        // 3 

        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                // 3.a 
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                RotateIntoMoveDirection();
            }
            else if(!destroyed)
            {
                // 3.b 
                StartCoroutine(Attack());
            }
        }
    }
    private void RotateIntoMoveDirection()
    {
        //1
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        //2
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        //3
        GameObject sprite = gameObject.transform.Find("SpriteObject").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle - 90, Vector3.forward);
    }
    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }
    IEnumerator Attack()
    {
        destroyed = true;
        SpawnerScript.EnemiesKilled = SpawnerScript.EnemiesKilled + 1;

        // AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        GameManagerBehavior_PLA gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior_PLA>();
        gameManager.Health -= 1;
        damageSound.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }
}
