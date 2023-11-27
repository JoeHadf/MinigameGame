using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public bool isHit { get; private set; }

    void Awake()
    {
        isHit = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            isHit = true;
        }
    }
}
