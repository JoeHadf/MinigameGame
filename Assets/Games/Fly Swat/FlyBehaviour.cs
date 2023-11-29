using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyBehaviour : PhasedEntity
{
    [SerializeField] private EntitySpeed flySpeed;
    [SerializeField] private EntityTime waitingTimeLowerBound;
    [SerializeField] private EntityTime waitingTimeUpperBound;

    [SerializeField] private Color oneHitColour;
    [SerializeField] private Color twoHitColour;

    private SpriteRenderer spriteRenderer;
    
    private Vector3 returningPosition = new Vector3(7, 0, 0);

    private Vector3 startingPosition;
    private Vector3 returningDirection;
    private float sqrDistanceToMove;
    private bool hasBeenHit;
    public int currentHits { get; private set; }
    
    public int hitCount { get; private set; }

    public void Initiate(int hitCount)
    {
        this.hitCount = hitCount;
    }
    
    private protected override void OnAwake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        currentHits = 0;
        hasBeenHit = false;
    }

    void Start()
    {
        transform.position = returningPosition;
        
        PhaseCondition waitingCondition = new RandomTimeCondition(this, waitingTimeLowerBound.GetTime(), waitingTimeUpperBound.GetTime());
        Phase waitingPhase = new Phase(ResetHasBeenHit, () => {}, waitingCondition);

        PhaseCondition movingCondition = new GoalCondition(HasFinishedMoving);
        Phase movingPhase = new Phase(() => {}, FlyCharge, movingCondition);

        PhaseCondition returningCondition = new GoalCondition(HasReturned);
        Phase returningPhase = new Phase(UpdateReturningVectors, FlyReturn, returningCondition);

        Phase[] flyPhases = new Phase[] { waitingPhase, movingPhase, returningPhase };
        SetUpPhases(flyPhases);
    }

    private void ResetHasBeenHit()
    {
        hasBeenHit = false;
    }

    private void FlyCharge()
    {
        transform.position += flySpeed * Time.deltaTime * Vector3.left;
    }

    private bool HasFinishedMoving()
    {
        bool hasHitEnd = transform.position.x < ScreenSpaceCalculator.minX;
        
        if (hasHitEnd)
        {
            TimerManager.GetInstance().EndGameEarly();
        }
        
        return hasBeenHit || transform.position.x < ScreenSpaceCalculator.minX;
    }

    private void UpdateReturningVectors()
    {
        startingPosition = transform.position;
        returningDirection = returningPosition - startingPosition;
        sqrDistanceToMove = returningDirection.sqrMagnitude;
        returningDirection.Normalize();
    }

    private void FlyReturn()
    {
        transform.position += flySpeed * Time.deltaTime * returningDirection;
    }

    private bool HasReturned()
    {
        return sqrDistanceToMove < (transform.position - startingPosition).sqrMagnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenHit && GetCurrentPhaseIndex() == 1 && collision.gameObject.CompareTag("Player"))
        {
            hasBeenHit = true;
            currentHits++;
            
            if (currentHits >= hitCount)
            {
                TimerManager.GetInstance().EndGameEarly();
            }
            
            spriteRenderer.color = GetColorFromHits(hitCount - currentHits);
        }
    }

    private Color GetColorFromHits(int hitsFromEnd)
    {
        if (hitsFromEnd == 2)
        {
            return oneHitColour;
        }

        return twoHitColour;
    }
}
