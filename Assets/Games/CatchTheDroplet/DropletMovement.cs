using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletMovement : MonoBehaviour
{
    public bool successfulCatch { get; private set; }

    void Awake()
    {
        successfulCatch = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        
        if(collision.gameObject.name == "Bucket(Clone)")
        {
            successfulCatch = true;
        }
    }
}
