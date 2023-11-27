using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    [SerializeField] private Color baseColour;
    [SerializeField] private Color hitColour;
    public bool isHit { get; private set; }

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        isHit = false;
    }

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = baseColour;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isHit)
            {
                spriteRenderer.color = hitColour;
                isHit = true;
            }
        }
    }
}
