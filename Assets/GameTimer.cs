using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float currentTime { get; private set; }

    public bool hasStarted;

    public bool hasFinished;

    public bool isActive;

    public bool isLocked;

    private void Awake()
    {
        currentTime = 0;
        hasFinished = false;
        hasStarted = true;
        isActive = false;
        isLocked = false;
    }

    public void SetTimer(float time)
    {
        currentTime = time;
        hasStarted = false;
        hasFinished = false;
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (isActive && !isLocked)
        {
            if (!hasStarted)
            {
                hasStarted = true;
            }
            else
            {
                if (!hasFinished)
                {
                    currentTime -= Time.fixedDeltaTime;

                    if (currentTime < 0)
                    {
                        hasFinished = true;
                    }
                }
            }
        }
    }
}
