using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private Sprite neutralArrow;
    [SerializeField] private Sprite pressedArrow;
    [SerializeField] private NoteLane lane;

    private SpriteRenderer spriteRenderer;
    private string keyCode;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        keyCode = GetKeyCode(lane);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            spriteRenderer.sprite = pressedArrow;
        }
        
        if(Input.GetKeyUp(keyCode))
        {
            spriteRenderer.sprite = neutralArrow;
        }
    }

    private string GetKeyCode(NoteLane noteLane)
    {
        switch (noteLane)
        {
            case NoteLane.LeftLane:
                return "left";
            case NoteLane.UpLane:
                return "up";
            case NoteLane.RightLane:
                return "right";
        }

        return "";
    }
}
