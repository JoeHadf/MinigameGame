using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasedEntity : MonoBehaviour
{
    private Phase[] phases;

    private bool isSetUp;

    public float currentTime { get; private set; }

    private int currentPhaseIndex;

    private int totalPhaseCount;

    void Awake()
    {
        isSetUp = false;
        currentTime = 0;
        
        OnAwake();
    }
    
    private protected virtual void OnAwake() { }

    void Update()
    {
        if (isSetUp)
        {
            currentTime += Time.deltaTime;

            GetCurrentPhase().updateBehaviour();

            if (GetCurrentPhase().condition.IsConditionMet())
            {
                NextPhase();
            }
        }
    }
    
    private Phase GetCurrentPhase()
    {
        return phases[currentPhaseIndex];
    }

    private protected void SetUpPhases(Phase[] phasesToSetUp)
    {
        if (!isSetUp)
        {
            this.phases = phasesToSetUp;
            totalPhaseCount = phases.Length;
            currentPhaseIndex = 0;
            currentTime = 0;
            isSetUp = true;

            GetCurrentPhase().startBehaviour();
        }
    }

    private protected int GetCurrentPhaseIndex()
    {
        return currentPhaseIndex;
    }

    private void NextPhase()
    {
        currentPhaseIndex = (currentPhaseIndex + 1) % totalPhaseCount;
        currentTime = 0;

        GetCurrentPhase().startBehaviour();
    }
}
