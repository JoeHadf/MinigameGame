using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private NoteLane lane;

    public SongBehaviour songBehaviour;
    
    void Start()
    {
        gameObject.tag = "Enemy";
        
        lane = (NoteLane) Random.Range(1, 4);
        SetupNote(lane);
    }

    void Update()
    {
        float distance = Time.deltaTime * songBehaviour.noteSpeed;
        transform.Translate(0, -distance, 0);
    }

    private void SetupNote(NoteLane noteLane)
    {
        transform.Rotate(Vector3.forward, GetRotation(noteLane));
        transform.Translate(GetLanePosition(noteLane), 0, 0);
    }

    private float GetRotation(NoteLane noteLane)
    {
        switch (noteLane)
        {
            case NoteLane.LeftLane:
                return -90;
            case NoteLane.UpLane:
                return 0;
            case NoteLane.RightLane:
                return 90;
        }

        return 0;
    }

    private float GetLanePosition(NoteLane noteLane)
    {
        switch (noteLane)
        {
            case NoteLane.LeftLane:
                return songBehaviour.leftLanePosition;
            case NoteLane.UpLane:
                return songBehaviour.upLanePosition;
            case NoteLane.RightLane:
                return songBehaviour.rightLanePosition;
        }

        return 0;
    }
}

enum NoteLane
{
    LeftLane = 1,
    UpLane = 2,
    RightLane = 3
}