using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class CityDefense : Game
{
    private CityBehaviour cityBehaviour;
    
    public CityDefense() : base(GameName.CityDefense) { }

    protected override void SetUpEasy()
    {
        ObjectSpawner objectSpawner = ObjectSpawner.Instance;
        GameObject swordsmanPrefab = Resources.Load("Games/CityDefense/Swordsman", typeof(GameObject)) as GameObject;
        objectSpawner.Spawn(swordsmanPrefab, Vector3.zero);
        
        GameObject cityPrefab = Resources.Load("Games/CityDefense/City", typeof(GameObject)) as GameObject;
        GameObject city = objectSpawner.Spawn(cityPrefab, Vector3.zero);
        cityBehaviour = city.GetComponent<CityBehaviour>();
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
        if (cityBehaviour.hasBeenDestroyed)
        {
            return false;
        }

        return true;
    }
}
