using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 4.5f;
    public bool shouldMove = true;

    private void Update()
    {
        if (shouldMove) //if shouldMove is true
        {
            LaserScrollUp(); //runs LaserScrollUp
        }

        if (this.transform.position.y >= 9f) //if lasers position moves beyond 9 on the Y Transform
        {
            DestroyLaser(); //runs DestroyLaser
        }
    }

    private void DestroyLaser()
    {
        for (int i = 0; i < GameManager.instance.spawnedLaserList.Count; i++) //increments through spawnedLaserList
        {
            if (GameManager.instance.spawnedLaserList[i] == this.gameObject) //if this gameObject matches the gameObject in spawnedLaserList at index i
            {
                GameManager.instance.spawnedLaserList.RemoveAt(i); //removes index i from the list
            }
        }
        Destroy(this.gameObject); //destroys the gameObject
    }

    public void LaserScrollUp()
    {
        //translates the transform with the Vector3 coordinates multiplied by scrollSpeed and Time.deltaTime 
        this.transform.position += (Vector3.up * _scrollSpeed) * Time.deltaTime;
    }
}
