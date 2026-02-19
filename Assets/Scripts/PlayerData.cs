using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int carsSelected;
    public int highScore;

    public PlayerData(int newCar, int bestScore)
    {
        carsSelected = newCar;
        highScore = bestScore;
    }
}
