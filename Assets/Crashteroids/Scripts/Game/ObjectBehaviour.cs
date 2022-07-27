using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 3f;
    [SerializeField] private int _deathValue;

    private void Update()
    {
        ObjectScrollDown();
    }

    public void ObjectScrollDown()
    {
        this.transform.position += (Vector3.down * _scrollSpeed) * Time.deltaTime;
    }

    public void DestroyObject(GameObject obj)
    {
        //play sfx
        //display particlefx/animation
        Destroy(obj);
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "Player":
                Debug.Log("PLAYER");
                //kill player
                break;
            case "Laser":
                Debug.Log("LASER");
                //increment player score
                GameManager.IncreaseScore(_deathValue);
                Debug.Log(GameManager.score);
                //destroy object
                DestroyObject(other.gameObject);
                DestroyObject(this.gameObject);
                break;
        }
    }
}
