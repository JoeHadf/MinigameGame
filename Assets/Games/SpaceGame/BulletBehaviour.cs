using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private EntitySpeed speed;
    
    public Vector3 direction = Vector3.zero;

    void Start()
    {
        gameObject.tag = "Enemy";
    }
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
}
