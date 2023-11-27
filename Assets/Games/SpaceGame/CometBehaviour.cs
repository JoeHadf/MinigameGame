using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CometBehaviour : PhasedEntity
{
    [SerializeField] private Sprite hazardSprite;
    [SerializeField] private Sprite cometSprite;
    [SerializeField] private EntityTime warningTime;
    [SerializeField] private EntityTime fallingTime;
    [SerializeField] private EntitySpeed fallingSpeed;

    private SpriteRenderer spriteRenderer;
    
    private protected override void OnAwake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        PhaseCondition warningDelay = new TimeCondition(this, warningTime.GetTime());
        Phase warningPhase = new Phase(StartWarningPhase, () => {}, warningDelay);

        PhaseCondition fallingDelay = new TimeCondition(this, fallingTime.GetTime());
        Phase fallingPhase = new Phase(StartFallingPhase, MoveComet, fallingDelay);

        Phase[] cometPhases = new Phase[] { warningPhase, fallingPhase };
        
        SetUpPhases(cometPhases);
    }

    private void StartWarningPhase()
    {
        spriteRenderer.sprite = hazardSprite;
        transform.position = ChooseNewPosition();
    }

    private void StartFallingPhase()
    {
        spriteRenderer.sprite = cometSprite;
        transform.position += new Vector3(0, 2, 0);
    }

    private void MoveComet()
    {
        transform.position += Vector3.down * (fallingSpeed * Time.deltaTime);
    }

    private Vector3 ChooseNewPosition()
    {
        float x = Random.Range(-1.0f, 1.0f);
        return ScreenSpaceCalculator.ScreenSpaceToWorldSpace(x, 2.0f / 3.0f);
    }
}
