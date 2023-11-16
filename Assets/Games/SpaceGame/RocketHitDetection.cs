using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHitDetection : MonoBehaviour
{
    public bool hasBeenHit { get; private set; }

    void Awake()
    {
        hasBeenHit = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hasBeenHit = true;
        }
    }
}
