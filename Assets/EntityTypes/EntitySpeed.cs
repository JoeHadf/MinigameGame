using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EntitySpeed
{
    [SerializeField] private float baseSpeed;

    public EntitySpeed(float baseSpeed)
    {
        this.baseSpeed = baseSpeed;
    }
    
    public static float operator *(EntitySpeed entitySpeed, float number)
    {
        return entitySpeed.baseSpeed * GameSpeed.speed * number;
    }

    public static float operator *(float number, EntitySpeed entitySpeed)
    {
        return number * entitySpeed.baseSpeed * GameSpeed.speed;
    }
}
