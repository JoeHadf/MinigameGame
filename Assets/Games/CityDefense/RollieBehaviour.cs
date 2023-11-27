using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RollieBehaviour : MonoBehaviour
{
    [SerializeField] private EntitySpeed entitySpeed;

    private float directionCoefficient = 1;

    void Start()
    {
        gameObject.tag = "Enemy";
    }
    void Update()
    {
        float distance = Time.deltaTime * entitySpeed * directionCoefficient;
        transform.position += distance * Vector3.right;
    }

    public void SetMovingLeft()
    {
        Vector3 scale = transform.localScale;
        scale = new Vector3(-scale.x, scale.y, scale.z);
        transform.localScale = scale;

        directionCoefficient = -1;
    }
}
