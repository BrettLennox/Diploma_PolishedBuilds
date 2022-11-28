using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private Vector2 _xBounds;
    [SerializeField] private float _spawnTimer = Mathf.Infinity;
    [SerializeField] private float _timeBetweenSpawn = 2f;
    public bool shouldSpawn = true;

    private void Update()
    {
        if (shouldSpawn) //if shouldSpawn
        {
            _spawnTimer += Time.deltaTime; //increments spawnTimer by Time.deltaTime
            if (_spawnTimer >= _timeBetweenSpawn) //if spawnTimer is greater than or equal to timeBetweenSpawn
            {
                //resets spawnTimer to 0
                _spawnTimer = 0f;
                //runs SpawnObject function
                SpawnObject();
            }
        }
    }

    public GameObject SpawnObject()
    {
        //creates a Vector2 with random coordinates within the set bounds
        Vector2 randomSpawnLocation = new Vector2(Random.Range(_xBounds.x, _xBounds.y), 9f);
        //instantiates asteroidPrefab at randomSpawnLocation, parented to this gameObjects transform
        var asteroid = Instantiate(_asteroidPrefab, randomSpawnLocation, Quaternion.identity, this.transform);
        //adds this asteroid to the GameManager spawnedObjectList
        GameManager.instance.spawnedObjectsList.Add(asteroid);
        //returns this asteroid to the function
        return asteroid;
    }
}
