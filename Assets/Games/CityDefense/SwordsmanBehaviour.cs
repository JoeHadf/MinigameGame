using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordsmanBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite idleSprite;

    [SerializeField] private Sprite swungSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider;

    private const float speed = 6.0f;
    private const float swingDelay = 0.2f;

    private float delayTimer = 0.0f;
    private bool isFacingRight = true;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;

        collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
            if (delayTimer <= 0)
            {
                EndSwordSwing();
            }
        }

        if (delayTimer <= 0)
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float horizontalMovement = speed * horizontalAxis * Time.deltaTime;
        
            transform.Translate(horizontalMovement, 0, 0);

            if (IsFacingNewDirection(horizontalAxis))
            {
                FlipDirection();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartSwordSwing();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            collider.enabled = false;
        }
    }

    private void StartSwordSwing()
    {
        collider.enabled = true;
        spriteRenderer.sprite = swungSprite;
        delayTimer = swingDelay;
    }

    private void EndSwordSwing()
    {
        collider.enabled = false;
        spriteRenderer.sprite = idleSprite;
    }

    private bool IsFacingNewDirection(float horizontalAxis)
    {
        if ((isFacingRight && horizontalAxis < 0 )||(!isFacingRight && horizontalAxis > 0))
        {
            isFacingRight = !isFacingRight;
            return true;
        }

        return false;
    }

    private void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale = new Vector3(-scale.x, scale.y, scale.z);
        transform.localScale = scale;
    }
}
