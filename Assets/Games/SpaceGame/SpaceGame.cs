using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class SpaceGame : Game
{
    private RocketController rocketController;
    public SpaceGame() : base(GameName.SpaceGame) { }

    protected override void SetUpEasy()
    {
        Vector3 rocketPos = ScreenSpaceCalculator.ScreenSpaceToWorldSpace(0, -0.5f);
        Vector3 enemyPos = ScreenSpaceCalculator.ScreenSpaceToWorldSpace(0.5f, 0.5f);

        ObjectSpawner objectSpawner = ObjectSpawner.Instance;
        
        GameObject rocketPrefab = Resources.Load("Games/SpaceGame/Rocket", typeof(GameObject)) as GameObject;
        GameObject rocket = objectSpawner.Spawn(rocketPrefab, rocketPos);

        rocketController = rocket.GetComponent<RocketController>();
            
        GameObject enemyPrefab = Resources.Load("Games/SpaceGame/Enemy", typeof(GameObject)) as GameObject;
        GameObject enemy = objectSpawner.Spawn(enemyPrefab, enemyPos);

        EnemyBehaviour enemy1Behaviour = enemy.GetComponent<EnemyBehaviour>();
        enemy1Behaviour.playerObject = rocket;
        
        GameObject cometPrefab = Resources.Load("Games/SpaceGame/Comet", typeof(GameObject)) as GameObject;
        
        objectSpawner.Spawn(cometPrefab, Vector3.zero);
        objectSpawner.Spawn(cometPrefab, Vector3.zero);
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
        if (rocketController.isHit)
        {
            return false;
        }

        return true;
    }
}
