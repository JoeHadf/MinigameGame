using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatController : MonoBehaviour
{
    [SerializeField] private EntityTime swatTime;
    [SerializeField] private EntityTime waitTime;

    private Vector3 downPosition = new Vector3(-6,-3,0);
    private Vector3 upPosition = new Vector3(-6,-0.5f,0);
    
    private float delayTimer;

    void Start()
    {
        transform.position = downPosition;
    }
    void Update()
    {
        delayTimer -= Time.deltaTime;
        
        if (delayTimer < 0 && Input.GetKeyDown("space"))
        {
            delayTimer = swatTime.GetTime() + waitTime.GetTime();
            transform.position = upPosition;
        }

        if (delayTimer < waitTime.GetTime())
        {
            transform.position = downPosition;
        }
    }
}
