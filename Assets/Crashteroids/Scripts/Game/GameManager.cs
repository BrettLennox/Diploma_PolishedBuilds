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
    public List<GameObject> spawnedLaserList;
    public static GameManager instance;
    public GameObject gameUI, gameOverUI;

    private void Awake()
    {
        instance = this; //creates a static instance of this class

        //if objectSpawnBehaviour is null finds Objects GameObject in scene and references the ObjectSpawnBehaviour script from it
        _objectSpawnBehaviour ??= GameObject.Find("Objects").GetComponent<ObjectSpawnBehaviour>();
    }

    private void Start()
    {
        //sets the score to 0
        score = 0;
        //runs UpdateScoreText function
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        //increased score by parsed in int amount
        score += amount;
        //runs UpdateScoreText function
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        //sets scoreText text to score (converting it to string)
        scoreText.text = score.ToString();
    }

    public void EndGame()
    {
        //disables GameUI
        gameUI.SetActive(false);
        //enables GameOverUI
        gameOverUI.SetActive(true);
        //updates gameOverScoreText text to Score: + score (converting it to string)
        gameOverScoreText.text = "Score: " + score.ToString();
        //sets objectSpawnBehaviour shouldSpawn bool to false //this is to disable objects from moving when the game is ended
        _objectSpawnBehaviour.shouldSpawn = false;
        foreach (GameObject asteroid in spawnedObjectsList) //increments though spawnedObectsList
        {
            //sets the objects shouldMove bool to falses
            asteroid.GetComponent<ObjectBehaviour>().shouldMove = false;
        }
        foreach(GameObject laser in spawnedLaserList) //increments through spawnedLaserList
        {
            //sets the laser shouldMove bool to false
            laser.GetComponent<LaserBehaviour>().shouldMove = false;
        }
    }

    public void StartGame()
    {
        //clears spawnedObjectList
        spawnedObjectsList.Clear();
        //clears spawnedLaserList
        spawnedLaserList.Clear();
        foreach(Transform transform in _objectSpawnBehaviour.transform) //finds all the transforms inside of the objectSpawnBehaviour transform
        {
            //destroys the transforms gameObject
            Destroy(transform.gameObject);
        }
        foreach (Transform transform in GameObject.Find("Lasers").transform) //finds all the transforms inside of the Lasers transform
        {
            //destroys the transforms gameObject
            Destroy(transform.gameObject);
        }
        //instantiate Player prefab using Resources.Load at the set position and rotation coordinates
        Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, -2, 0), Quaternion.Euler(90, -180, 0));
        //sets the score to 0
        score = 0;
        //sets objectSpawnBehaviour to true
        _objectSpawnBehaviour.shouldSpawn = true;
        //runs UpdateScoreText function
        UpdateScoreText();
    }
}
