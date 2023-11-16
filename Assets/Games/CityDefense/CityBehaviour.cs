using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CityBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject rollie;
    [SerializeField] private float spawnAverage;
    [SerializeField] private float spawnRange;

    private SpriteRenderer spriteRenderer;

    private float leftTimer;
    private float rightTimer;

    private Vector3 leftPosition;
    private Vector3 rightPosition;

    public bool hasBeenDestroyed { get; private set; }

    void Awake()
    {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float minX = -bounds.x;
        float maxX = bounds.x;

        leftPosition = new Vector3(minX, 0, 0);
        rightPosition = new Vector3(maxX, 0, 0);

        leftTimer = ChooseNewTime();
        rightTimer = ChooseNewTime();

        hasBeenDestroyed = false;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        leftTimer -= Time.deltaTime;
        rightTimer -= Time.deltaTime;

        if (leftTimer <= 0)
        {
            leftTimer = ChooseNewTime();
            SpawnRollie(false);
        }

        if (rightTimer <= 0)
        {
            rightTimer = ChooseNewTime();
            SpawnRollie(true);
        }
    }

    private float ChooseNewTime()
    {
        return Random.Range(spawnAverage - spawnRange, spawnAverage + spawnRange);
    }

    private void SpawnRollie(bool spawnOnRight)
    {
        Vector3 spawnPosition;
        
        if (spawnOnRight)
        {
            spawnPosition = rightPosition;
        }
        else
        {
            spawnPosition = leftPosition;
        }
        
        GameObject currentRollie = Instantiate(rollie, spawnPosition, Quaternion.identity, transform.parent);
        if (spawnOnRight)
        {
            RollieBehaviour rollieBehaviour = currentRollie.GetComponent<RollieBehaviour>();
            rollieBehaviour.SetMovingLeft();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hasBeenDestroyed = true;
            spriteRenderer.color = Color.red;
        }
    }
}
