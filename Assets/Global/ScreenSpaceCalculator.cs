using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenSpaceCalculator
{
    public static float minX { get; private set; }
    public static float maxX { get; private set; }
    public static float minY { get; private set; }
    public static float maxY { get; private set; }
    
    private const float maxXCoord = 8;
    private const float maxYCoord = 4.5f;
    
    static ScreenSpaceCalculator()
    {
        minX = -maxXCoord;
        maxX = maxXCoord;
        minY = -maxYCoord;
        maxY = maxYCoord;
    }

    public static Vector3 ScreenSpaceToWorldSpace(Vector2 screenSpace)
    {
        return new Vector3(screenSpace.x * maxX, screenSpace.y * maxY, 0);
    }
    
    public static Vector3 ScreenSpaceToWorldSpace(float x, float y)
    {
        return new Vector3(x * maxX, y * maxY, 0);
    }

    public static Vector3 GetRandomPosition()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        return ScreenSpaceToWorldSpace(x, y);
    }
}