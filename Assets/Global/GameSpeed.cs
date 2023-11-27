using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameSpeed
{
    public static float speed { get; private set; }

    private const float speedIncrement = 1.2f;
    
    static GameSpeed()
    {
        speed = 1;
    }

    public static void IncreaseGameSpeed()
    {
        speed *= speedIncrement;
    }
    
}
