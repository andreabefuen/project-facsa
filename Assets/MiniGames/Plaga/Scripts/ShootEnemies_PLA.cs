using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies_PLA : MonoBehaviour {

    private float lastShotTime;
    private TowerData_PLA towerData;
    public List<GameObject> enemiesInRange;
    AudioSource shootSound;
    // Use this for initialization
    void Start () {

        shootSound = GetComponent<AudioSource>();
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        towerData = gameObject.GetComponentInChildren<TowerData_PLA>();

    }

    // Update is called once per frame
    void Update () {
        GameObject target = null;
        // 1
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {

            float distanceToGoal = enemy.GetComponent<MoveEnemy_PLA>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // 2
        if (target != null)
        {
            if (Time.time - lastShotTime > towerData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
            // 3
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI + 90f,
                new Vector3(0, 0, 1));
        }

    }
    void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = towerData.CurrentLevel.bullet;
        // 1 
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior_PLA bulletComp = newBullet.GetComponent<BulletBehavior_PLA>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;

        // sound
        shootSound.Play();

    }
    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 2

        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate_PLA del =
                other.gameObject.GetComponent<EnemyDestructionDelegate_PLA>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    // 3
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate_PLA del =
                other.gameObject.GetComponent<EnemyDestructionDelegate_PLA>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

}
