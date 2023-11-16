using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;

    public GameObject playerObject;

    private EnemyMovingState currentState;

    private Vector3 movingToPosition;
    private int currentShotCount;

    private const int totalShots = 3;
    private const float shotDelay = 0.5f;

    private float timer;
    
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    void Awake()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -Bounds.x;
        maxX = Bounds.x;
        minY = 0;
        maxY = Bounds.y;

        movingToPosition = ChooseNewPosition();
        currentState = EnemyMovingState.Moving;

    }
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (currentState == EnemyMovingState.Moving)
        {
            Vector3 movementDirection = movingToPosition - transform.position;
            movementDirection.Normalize();
            transform.position += movementDirection * (speed * Time.deltaTime);

            if (timer < 0)
            {
                currentState = EnemyMovingState.Shooting;
                timer = shotDelay;
            }

        }
        else if (currentState == EnemyMovingState.Shooting)
        {
            if (timer < 0)
            {
                GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity, transform.parent);
                Destroy(currentBullet, 5);
                BulletBehaviour behaviour = currentBullet.GetComponent<BulletBehaviour>();
                Vector3 playerLocation = (playerObject == null) ? transform.position : playerObject.transform.position;
                Vector3 direction = playerLocation - transform.position;
                direction.Normalize();
                behaviour.direction = (direction == Vector3.zero) ? Vector3.down : direction;
                
                currentShotCount++;

                if (currentShotCount > totalShots)
                {
                    currentShotCount = 0;
                    currentState = EnemyMovingState.Moving;

                    movingToPosition = ChooseNewPosition();
                    float distanceToNewPosition = (transform.position - movingToPosition).magnitude;
                    float timeToNewPosition = distanceToNewPosition / speed;
                    timer = timeToNewPosition;
                }
                else
                {
                    timer = shotDelay;
                }
            }
        }
    }

    private Vector3 ChooseNewPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector3(x, y, 0);

    }

    private enum EnemyMovingState
    {
        Null = 0,
        Moving = 1,
        Shooting = 2
    }
}
