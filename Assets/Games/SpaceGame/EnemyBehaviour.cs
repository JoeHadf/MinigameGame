using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviour : PhasedEntity
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private EntitySpeed speed;
    [SerializeField] private int totalShots;
    [SerializeField] private EntityTime shotDelay;
    
    public GameObject playerObject;

    private Vector3 startingPosition;
    private Vector3 movingDirection;
    private float sqrDistanceToMove;

    void Start()
    {
        PhaseCondition hasMovedToPosition = new GoalCondition(HasMovedToPosition);
        Phase movingPhase = new Phase(ChooseNewPosition, MoveTowardsPosition, hasMovedToPosition);

        PhaseCondition shootDelay = new TimeCondition(this, shotDelay.GetTime());
        Phase shootingPhase = new Phase(ShootBullet, () => { }, shootDelay);

        int phaseCount = 1 + totalShots;

        Phase[] enemyPhases = new Phase[phaseCount];

        enemyPhases[0] = movingPhase;
        for (int i = 1; i < phaseCount; i++)
        {
            enemyPhases[i] = shootingPhase;
        }
        
        SetUpPhases(enemyPhases);
    }
    
    private void ChooseNewPosition()
    {
        startingPosition = transform.position;
        
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(0.0f, 1.0f);
        Vector3 movingToPosition = ScreenSpaceCalculator.ScreenSpaceToWorldSpace(x, y);
        
        movingDirection = movingToPosition - startingPosition;
        sqrDistanceToMove = movingDirection.sqrMagnitude;
        movingDirection.Normalize();
    }

    private void MoveTowardsPosition()
    {
        transform.position += movingDirection * (speed * Time.deltaTime);
    }

    private bool HasMovedToPosition()
    {
        Vector3 currentPosition = transform.position;
        float sqrDistanceToStart = (currentPosition - startingPosition).sqrMagnitude;

        if (sqrDistanceToStart >= sqrDistanceToMove)
        {
            return true;
        }

        return false;
    }

    private void ShootBullet()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform.parent);
        Destroy(currentBullet, 5);
        BulletBehaviour behaviour = currentBullet.GetComponent<BulletBehaviour>();
        Vector3 playerLocation = (playerObject == null) ? transform.position : playerObject.transform.position;
        Vector3 direction = playerLocation - transform.position;
        direction.Normalize();
        behaviour.direction = (direction == Vector3.zero) ? Vector3.down : direction;
    }
}
