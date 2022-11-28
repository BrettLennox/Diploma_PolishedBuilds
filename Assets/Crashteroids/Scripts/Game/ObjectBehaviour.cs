using System;
using System.Numerics;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _scrollSpeed = 3f;
    [SerializeField] private int _deathValue;
    [Range(0, 2)] private float _sizeScale, _speedScale, _rotateDir;
    public bool shouldMove = true;

    private void OnEnable()
    {
        CreateScaleData(); //runs CreateScaleData
        UpdateScaledData(); //runs UpdateScaleData
    }

    private void UpdateScaledData() //adjusts scrollSpeed and localScale based on the scaledata randomly generated
    {
        _scrollSpeed *= _speedScale; 
        transform.localScale *= _sizeScale;
    }

    private void CreateScaleData() //creates a random scale amount for size, speed and rotation
    {
        float t = UnityEngine.Random.Range(0.5f, 1.5f);
        float r;
        float f = UnityEngine.Random.Range(0, 2);
        switch (f)
        {
            case 0:
                r = UnityEngine.Random.Range(10f, 30f);
                _rotateDir = r;
                break;
            case 1:
                r = UnityEngine.Random.Range(-10f, -30f);
                _rotateDir = r;
                break;
        }

        _sizeScale = t;
        _speedScale = t;
    }

    private void Update()
    {
        if (shouldMove) //if shouldMove is true
        {
            //runs ObjectScrollDown and ObjectRotation functions
            ObjectScrollDown();
            ObjectRotation();
        }
    }

    public void ObjectScrollDown() //updates the objects position to scroll downwards multiplied by the scrollSpeed value
    {
        this.transform.position += (UnityEngine.Vector3.down * _scrollSpeed) * Time.deltaTime;
    }

    public void ObjectRotation() //rotates the object 
    {
        transform.Rotate(0, 0, _rotateDir * Time.deltaTime, Space.Self);
    }

    public void DestroyObject(GameObject obj) //destroys the passed in GameObject
    {
        GameManager.instance.spawnedObjectsList.Remove(this.gameObject);
        Destroy(obj);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player": //if Player
                //destroy player gameObject
                Destroy(other.gameObject);
                //runs GameManager EndGame function
                GameManager.instance.EndGame();
                break;
            case "Laser": //if Laser
                //runs GameManager IncreaseScore function
                GameObject.Find("GameManager").GetComponent<GameManager>().IncreaseScore(_deathValue);
                for(int i = 0; i < GameManager.instance.spawnedLaserList.Count; i++) //increments through GameManager spawnedLaserList
                {
                    if(GameManager.instance.spawnedLaserList[i] == other.gameObject) //if GameManager spawnedLaserList at index i matches this gameObject
                    {
                        //remove from spawnedLaserList at index i
                        GameManager.instance.spawnedLaserList.RemoveAt(i);
                    }
                }
                DestroyObject(other.gameObject); //perform DestroyObject function with other.gameObject passed in
                DestroyObject(this.gameObject); //perform DestroyObject function with this.gameObject passed in
                break;
        }
    }
}