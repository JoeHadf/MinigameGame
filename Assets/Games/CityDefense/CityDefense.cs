using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class CityDefense : Game
{
    private GameObject city;
    public CityDefense(GameObject parent) : base(GameType.Boss, GameName.CityDefense, parent)
    {
    }

    public override void SetUpGame()
    {
        GameObject swordsmanPrefab = Resources.Load("Games/CityDefense/Swordsman", typeof(GameObject)) as GameObject;
        Object.Instantiate(swordsmanPrefab, Vector3.zero, Quaternion.identity, objectsParent.transform);
        
        GameObject cityPrefab = Resources.Load("Games/CityDefense/City", typeof(GameObject)) as GameObject;
        city = Object.Instantiate(cityPrefab, Vector3.zero, Quaternion.identity, objectsParent.transform);
    }

    public override GameSuccessState GetSuccessState()
    {
        CityBehaviour cityBehaviour = city.GetComponent<CityBehaviour>();
        if (cityBehaviour.hasBeenDestroyed)
        {
            return GameSuccessState.Failure;
        }

        return GameSuccessState.Success;
    }
}
