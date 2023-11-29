using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class FlySwat : Game
{
    private GameObject swatPrefab;
    private GameObject flyPrefab;

    private FlyBehaviour flyBehaviour;
    
    public FlySwat() : base(GameName.FlySwat)
    {
        swatPrefab = Resources.Load("Games/FlySwat/Swat", typeof(GameObject)) as GameObject;
        flyPrefab = Resources.Load("Games/FlySwat/Fly", typeof(GameObject)) as GameObject;
    }

    protected override void SetUpEasy()
    {
        objectSpawner.Spawn(swatPrefab);
        GameObject fly = objectSpawner.Spawn(flyPrefab);
        flyBehaviour = fly.GetComponent<FlyBehaviour>();
        flyBehaviour.Initiate(1);
    }

    protected override void SetUpMedium()
    {
        objectSpawner.Spawn(swatPrefab);
        GameObject fly = objectSpawner.Spawn(flyPrefab);
        flyBehaviour = fly.GetComponent<FlyBehaviour>();
        flyBehaviour.Initiate(2);
    }

    protected override void SetUpHard()
    {
        objectSpawner.Spawn(swatPrefab);
        GameObject fly = objectSpawner.Spawn(flyPrefab);
        flyBehaviour = fly.GetComponent<FlyBehaviour>();
        flyBehaviour.Initiate(3);
    }

    public override bool IsSuccess()
    {
        if (flyBehaviour.currentHits >= flyBehaviour.hitCount)
        {
            return true;
        }

        return false;
    }
}
