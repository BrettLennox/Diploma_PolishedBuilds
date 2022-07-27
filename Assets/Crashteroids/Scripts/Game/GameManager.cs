using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;

    public static void IncreaseScore(int amount)
    {
        score += amount;
    }
}
