using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] DuckMovement playerPrefab;
    public DuckMovement GetPlayer()
    {
        return Instantiate<DuckMovement>(playerPrefab);
    }
}
