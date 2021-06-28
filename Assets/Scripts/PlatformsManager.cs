using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformsManager : MonoBehaviour
{
    private const int ENEMY_DISTANCE = 3;
    public static PlatformsManager Instance;

    private int numberOfPlatforms = 6;
    private float levelWidth = 10f;
    private float platformWidth = 0.5f;
    private float minimumYDifference = 4f;
    private float maximumYDifference = 5f;
    private float minimumYDifference1 = 5f;
    private float maximumYDifference1 = 6f;
    private float minimumYDifference2 = 5.5f;
    private float maximumYDifference2 = 6.5f;
    private float minimumYDifference3 = 6.5f;
    private float maximumYDifference3 = 7.5f;
    private GameObject platformPrefab;
    private GameObject enemyPrefab;
    private GameObject enemy;
    private List<GameObject> platformsList = new List<GameObject>();
    private Vector3 lastSpawnPosition;

    private void Awake()
    {
        Instance = this;

        platformPrefab = Resources.Load("Platform") as GameObject;
        enemyPrefab = Resources.Load("Enemy") as GameObject;
        lastSpawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            lastSpawnPosition.y += UnityEngine.Random.Range(minimumYDifference, maximumYDifference);
            lastSpawnPosition.x += UnityEngine.Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, lastSpawnPosition, Quaternion.identity, transform);
        }

        Vector3 enemyPosition = lastSpawnPosition + new Vector3(UnityEngine.Random.Range(-levelWidth, levelWidth) + ENEMY_DISTANCE, UnityEngine.Random.Range(minimumYDifference, maximumYDifference) + ENEMY_DISTANCE, 0);
        enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.LookRotation(Vector3.right), transform);

        foreach (Platform platform in FindObjectsOfType<Platform>())
        {
            platformsList.Add(platform.gameObject);
        }
    }

    private void FixedUpdate()
    {
        switch (GameManager.Instance.Difficulty)
        {
            case 1: minimumYDifference = minimumYDifference1; maximumYDifference = maximumYDifference1; break;
            case 2: minimumYDifference = minimumYDifference2; maximumYDifference = maximumYDifference2; break;
            case 3: minimumYDifference = minimumYDifference3; maximumYDifference = maximumYDifference3; break;
        }

        foreach (GameObject platform in platformsList)
        {
            if (Player.Instance.GetComponent<Rigidbody>().velocity.y <= 0)
            {
                platform.GetComponent<BoxCollider>().enabled = true;
                enemy.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                platform.GetComponent<BoxCollider>().enabled = false;
                enemy.GetComponent<BoxCollider>().enabled = false;
            }

            if (Player.Instance.transform.position.y - 20 > platform.transform.position.y)
            {
                lastSpawnPosition.y += UnityEngine.Random.Range(minimumYDifference, maximumYDifference);
                lastSpawnPosition.x += UnityEngine.Random.Range(-levelWidth, levelWidth);
                platform.transform.position = lastSpawnPosition;
                Vector3 platformScale = new Vector3(3f, 1f, 1f);
                platformScale.x += UnityEngine.Random.Range(-platformWidth, platformWidth);
                platform.transform.localScale = platformScale;
            }
        }

        if (Player.Instance.transform.position.y - 20 > enemy.transform.position.y)
        {
            Vector3 enemyPosition = lastSpawnPosition + new Vector3(UnityEngine.Random.Range(-levelWidth, levelWidth) + ENEMY_DISTANCE, UnityEngine.Random.Range(minimumYDifference, maximumYDifference) + ENEMY_DISTANCE, 0);
            enemy.transform.position = enemyPosition;
        }
    }
}
