using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameLevel
{
    public static Level level { get; private set; }
    
    public static int numberOfLevelIncreases { get; private set; }
    

    static GameLevel()
    {
        level = Level.Easy;
        numberOfLevelIncreases = Enum.GetValues(typeof(Level)).Length - 1;
    }

    public static void IncreaseGameLevel()
    {
        switch (level)
        {
            case Level.Easy:
                level = Level.Medium;
                break;
            case Level.Medium:
                level = Level.Hard;
                break;
            default:
                Debug.Log("No valid level to increase to");
                break;
        }
    }

    public enum Level
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }
}
