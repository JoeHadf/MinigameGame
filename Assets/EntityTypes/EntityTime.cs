using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityTime
{
    [SerializeField] private float baseTime;

    public EntityTime(float baseTime)
    {
        this.baseTime = baseTime;
    }

    public float GetTime()
    {
        return baseTime / GameSpeed.speed;
    }
}
