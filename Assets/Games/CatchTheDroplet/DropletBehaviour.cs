using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletBehaviour : MonoBehaviour
{
    [SerializeField] private EntitySpeed speed;
    public bool successfulCatch { get; private set; }

    void Awake()
    {
        successfulCatch = false;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        
        if(collision.gameObject.CompareTag("Player"))
        {
            successfulCatch = true;
        }
    }
}
