using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class CometBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite hazardSprite;
    [SerializeField] private Sprite cometSprite;

    private SpriteRenderer spriteRenderer;

    private float minX;
    private float maxX;
    private float yValue;

    private CometMovingState currentState;

    private float timer;
    private const float warningTime = 3;
    private const float fallingTime = 5;
    private const float fallingSpeed = 10;
    
    
    void Awake()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -Bounds.x;
        maxX = Bounds.x;
        yValue = Bounds.y * 2/3;

        timer = warningTime;
        currentState = CometMovingState.Warning;

        transform.position = ChooseNewPosition();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = hazardSprite;
    }

    void Start()
    {
        gameObject.tag = "Enemy";
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (currentState == CometMovingState.Warning)
        {
            if (timer < 0)
            {
                timer = fallingTime;
                currentState = CometMovingState.Falling;
                spriteRenderer.sprite = cometSprite;

            }
        }
        else if (currentState == CometMovingState.Falling)
        {
            transform.position += Vector3.down * (fallingSpeed * Time.deltaTime);
            if (timer < 0)
            {
                timer = warningTime;
                currentState = CometMovingState.Warning;
                spriteRenderer.sprite = hazardSprite;
                transform.position = ChooseNewPosition();
            }
        }
    }

    private Vector3 ChooseNewPosition()
    {
        float x = Random.Range(minX, maxX);
        return new Vector3(x, yValue, 0);
    }
    private enum CometMovingState
    {
        Null = 0,
        Falling = 1,
        Warning = 2
    }
}
