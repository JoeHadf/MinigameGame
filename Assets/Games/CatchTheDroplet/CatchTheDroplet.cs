using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class CatchTheDroplet : Game
{
    private DropletBehaviour dropletBehaviour;
    
    public CatchTheDroplet() : base(GameName.CatchTheDroplet) { }

    protected override void SetUpEasy()
    {
        float dropletX = Random.Range(-1.0f, 1.0f);
        Vector3 dropletPos = ScreenSpaceCalculator.ScreenSpaceToWorldSpace(dropletX, 1);
            
        float bucketX = Random.Range(-1.0f, 1.0f);
        Vector3 bucketPos = ScreenSpaceCalculator.ScreenSpaceToWorldSpace(bucketX, -0.75f);
        
        ObjectSpawner objectSpawner = ObjectSpawner.Instance;
        
        GameObject dropletPrefab = Resources.Load("Games/CatchTheDroplet/Droplet", typeof(GameObject)) as GameObject;
        GameObject droplet = objectSpawner.Spawn(dropletPrefab, dropletPos);
        dropletBehaviour = droplet.GetComponent<DropletBehaviour>();
            
        GameObject bucketPrefab = Resources.Load("Games/CatchTheDroplet/Bucket", typeof(GameObject)) as GameObject;
        objectSpawner.Spawn(bucketPrefab, bucketPos);
    }

    protected override void SetUpMedium()
    {
        SetUpEasy();
    }

    protected override void SetUpHard()
    {
        SetUpEasy();
    }


    public override bool IsSuccess()
    {
        if (dropletBehaviour.successfulCatch)
        {
            return true;
        }

        return false;
    }
}
