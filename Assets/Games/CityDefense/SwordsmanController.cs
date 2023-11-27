using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordsmanController : MonoBehaviour
{
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite swungSprite;
    [SerializeField] private float swingDelay = 0.2f;

    private SpriteRenderer spriteRenderer;
    private Collider2D myCollider;
    private FourDirectionalMovement fourDirMovement;

    private float delayTimer = 0.0f;
    private bool isFacingRight = true;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;

        myCollider = gameObject.GetComponent<Collider2D>();
        myCollider.enabled = false;

        fourDirMovement = gameObject.GetComponent<FourDirectionalMovement>();
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
            if (IsFacingNewDirection())
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
            myCollider.enabled = false;
        }
    }

    private void StartSwordSwing()
    {
        myCollider.enabled = true;
        spriteRenderer.sprite = swungSprite;
        delayTimer = swingDelay;
        fourDirMovement.SetActive(false);
    }

    private void EndSwordSwing()
    {
        myCollider.enabled = false;
        spriteRenderer.sprite = idleSprite;
        fourDirMovement.SetActive(true);
    }

    private bool IsFacingNewDirection()
    {
        if ((isFacingRight && fourDirMovement.IsMovingLeft())||(!isFacingRight && fourDirMovement.IsMovingRight()))
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
