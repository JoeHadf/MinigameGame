using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourDirectionalMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        float horizontalMovement = speed * horizontalAxis * Time.deltaTime;
        float verticalMovement = speed * verticalAxis * Time.deltaTime;
        
        transform.Translate(horizontalMovement, verticalMovement, 0);
    }
}
