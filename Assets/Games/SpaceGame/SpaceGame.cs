using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class SpaceGame : Game
{
    private GameObject rocket;
    private GameObject enemy1;
    
    public SpaceGame(GameObject parent) : base(GameType.Boss, GameName.SpaceGame, parent)
    {
        
    }

    public override void SetUpGame()
    {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        float minX = -bounds.x;
        float maxX = bounds.x;
        float minY = -bounds.y;
        float maxY = bounds.y;

        Vector3 rocketPos = new Vector3(0, minY / 2, 0);
        Vector3 enemy1Pos = new Vector3(minX / 2, maxY / 2, 0);
        Vector3 enemy2Pos = new Vector3(maxX / 2, maxY / 2, 0);
        
        GameObject rocketPrefab = Resources.Load("Games/SpaceGame/Rocket", typeof(GameObject)) as GameObject;
        rocket = Object.Instantiate(rocketPrefab, rocketPos, Quaternion.identity, objectsParent.transform);
            
        GameObject enemyPrefab = Resources.Load("Games/SpaceGame/Enemy", typeof(GameObject)) as GameObject;
        
        enemy1 = Object.Instantiate(enemyPrefab, enemy1Pos, Quaternion.identity, objectsParent.transform);

        EnemyBehaviour enemy1Behaviour = enemy1.GetComponent<EnemyBehaviour>();
        enemy1Behaviour.playerObject = rocket;
        
        GameObject cometPrefab = Resources.Load("Games/SpaceGame/Comet", typeof(GameObject)) as GameObject;
        
        Object.Instantiate(cometPrefab, Vector3.zero, Quaternion.identity, objectsParent.transform);
        Object.Instantiate(cometPrefab, Vector3.zero, Quaternion.identity, objectsParent.transform);
    }

    public override GameSuccessState GetSuccessState()
    {
        RocketHitDetection hitDetection = rocket.GetComponent<RocketHitDetection>();

        if (hitDetection.hasBeenHit)
        {
            return GameSuccessState.Failure;
        }

        return GameSuccessState.Success;
    }
}
