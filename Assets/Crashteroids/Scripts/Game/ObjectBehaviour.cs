using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 3f;

    private void Update()
    {
        ObjectScrollDown();
    }

    public void ObjectScrollDown()
    {
        this.transform.position += (Vector3.down * _scrollSpeed) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //var
    }
}
