using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerPrefab;
    [SerializeField] private ObjectBehaviour objectPrefab;
    [SerializeField] private LaserBehaviour laserPrefab;
    [SerializeField] private ObjectSpawnBehaviour objectSpawnPrefab;

    public PlayerMovement GetPlayer() //returns and instance of the playerPrefab
    {
        return Instantiate<PlayerMovement>(playerPrefab);
    }

    public ObjectBehaviour GetObject() //returns and instance of the objectPrefab
    {
        return Instantiate<ObjectBehaviour>(objectPrefab); 
    }

    public LaserBehaviour GetLaser() //returns and instance of the laserPrefab
    {
        return Instantiate<LaserBehaviour>(laserPrefab); 
    }

    public ObjectSpawnBehaviour GetObjectSpawn() //returns and instance of the objectSpawnPrefab
    {
        return Instantiate<ObjectSpawnBehaviour>(objectSpawnPrefab); 
    }
}
