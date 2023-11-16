using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class CatchTheDroplet : Game
{
    private GameObject droplet;
    private GameObject bucket;

    private const float dropletHeight = 3;
    private const float bucketHeight = -3;
    
    public CatchTheDroplet(GameObject parent) : base(GameType.Regular, GameName.CatchTheDroplet, parent)
    {
        
    }

    public override void SetUpGame()
    {
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float minX = -Bounds.x;
        float maxX = Bounds.x;
        
        float dropletX = Random.Range(minX, maxX);
        Vector3 dropletPos = new Vector3(dropletX, dropletHeight, 0);
            
        float bucketX = Random.Range(minX, maxX);
        Vector3 bucketPos = new Vector3(bucketX, bucketHeight, 0);
        
        GameObject dropletPrefab = Resources.Load("Games/CatchTheDroplet/Droplet", typeof(GameObject)) as GameObject;
        droplet = GameObject.Instantiate(dropletPrefab, dropletPos, Quaternion.identity, objectsParent.transform);
            
        GameObject bucketPrefab = Resources.Load("Games/CatchTheDroplet/Bucket", typeof(GameObject)) as GameObject;
        bucket = GameObject.Instantiate(bucketPrefab, bucketPos, Quaternion.identity, objectsParent.transform);
    }

    public override GameSuccessState GetSuccessState()
    {
        DropletMovement dropletMovement = droplet.GetComponent<DropletMovement>();

        if (dropletMovement.successfulCatch)
        {
            return GameSuccessState.Success;
        }

        return GameSuccessState.Failure;
    }
}
