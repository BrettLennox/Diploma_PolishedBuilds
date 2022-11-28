using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private Transform _laserSpawnPoint;
    [SerializeField] private Transform _laserParent;
    [SerializeField] private float _shotTimer = Mathf.Infinity;
    [SerializeField] private float _timeBetweenShots = 0.6f;
    Vector3 moveDir;
    public float speed = 5f;
    CharacterController charController;

    private void Awake()
    {
        //if charController is null
        //sets the charController to CharacterController attached to GameObject
        charController ??= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //increments shotTimer by Time.deltaTime
        _shotTimer += Time.deltaTime;

        //runs CalculateMovement function
        CalculateMovement();
        //runs Move function with parsed in moveDir variable
        Move(moveDir);

        //if user inputs Space key AND shotTimer is greater than timeBetweenShots
        if (Input.GetButton("P1 R1") && _shotTimer >= _timeBetweenShots)
        {
            //resets shotTimer to 0
            _shotTimer = 0;
            //runs SpawnLaser function
            SpawnLaser();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            GameManager.instance.Quit();
        }
    }

    

    private void CalculateMovement()
    {
        //sets moveDir to a new Vector3 with x set to Horizontal Axis input and y set to Vertical Axis input
        moveDir = new Vector3(Input.GetAxisRaw("P1 Hori"), Input.GetAxisRaw("P1 Verti"), 0);
        //multiplies moveDir by speed
        moveDir *= speed;
    }

    public void Move(Vector3 dir)
    {
        //runs CharacterController Move function with parsed in Vector3 dir as the Move Vector3 coordinates
        //multiplied by Time.deltaTime
        charController.Move(dir * Time.deltaTime);
    }

    public GameObject SpawnLaser()
    {
        //instantiates LaserPrefab at the laserSpawnPoint position, parented to Lasers GameObject in scene
        var laser = Instantiate(_laserPrefab, _laserSpawnPoint.position, Quaternion.identity, GameObject.Find("Lasers").transform);
        //adds laser to GameManager spawnedLaserList
        GameManager.instance.spawnedLaserList.Add(laser);
        //returns laser GameObject
        return laser;
    }
}
