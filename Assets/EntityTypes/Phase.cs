using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase
{
    public Action startBehaviour;
    public Action updateBehaviour;
    public PhaseCondition condition;

    public Phase(Action startBehaviour, Action updateBehaviour, PhaseCondition condition)
    {
        this.startBehaviour = startBehaviour;
        this.updateBehaviour = updateBehaviour;
        this.condition = condition;
    }
}

public abstract class PhaseCondition
{
    public abstract bool IsConditionMet();
}

public class TimeCondition : PhaseCondition
{
    private PhasedEntity phasedEntity;

    private float time;

    public TimeCondition(PhasedEntity phasedEntity, float time)
    {
        this.phasedEntity = phasedEntity;
        this.time = time;
    }
        
    public override bool IsConditionMet()
    {
        if (phasedEntity.currentTime >= time)
        {
            return true;
        }

        return false;
    }
}

public class GoalCondition : PhaseCondition
{
    private Func<bool> goal;
        
    public GoalCondition(Func<bool> goal)
    {
        this.goal = goal;
    }
    public override bool IsConditionMet()
    {
        return goal();
    }
}
