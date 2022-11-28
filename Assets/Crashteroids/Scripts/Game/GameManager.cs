using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText, gameOverScoreText;
    public ObjectSpawnBehaviour _objectSpawnBehaviour;
    public List<GameObject> spawnedObjectsList;
    public static GameManager instance;
    public GameObject gameUI, gameOverUI;

    private void Awake()
    {
        instance = this;
        _objectSpawnBehaviour ??= GameObject.Find("Objects").GetComponent<ObjectSpawnBehaviour>();
    }

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void EndGame()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
        _objectSpawnBehaviour.shouldSpawn = false;
        foreach(GameObject asteroid in spawnedObjectsList)
        {
            asteroid.GetComponent<ObjectBehaviour>().shouldMove = false;
        }
    }

    public void StartGame()
    {
        _objectSpawnBehaviour.shouldSpawn = true;
        if(spawnedObjectsList.Count >= 1)
        {
            for(int i = 0; i < spawnedObjectsList.Count; i++)
            {
                Destroy(spawnedObjectsList[i].gameObject);
                spawnedObjectsList.Remove(spawnedObjectsList[i]);
            }
        }
    }
}
