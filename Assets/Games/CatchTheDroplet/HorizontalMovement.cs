using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float horizontalMovement = speed * horizontalAxis * Time.deltaTime;
        
        transform.Translate(horizontalMovement, 0, 0);
    }
}
