using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Games
{
    public abstract class Game
    {
        public GameType gameType;

        public GameName gameName;

        public GameObject objectsParent;
    
        public Game(GameType type, GameName name, GameObject parent)
        {
            gameType = type;
            gameName = name;
            objectsParent = parent;
        }
    
        public abstract void SetUpGame();

        public abstract GameSuccessState GetSuccessState();

        public void CleanUpGame()
        {
            foreach (Transform child in objectsParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public enum GameType
    {
        Null = 0,
        Regular = 1,
        Boss = 2
    }

    public enum GameName
    {
        Null = 0,
        SquareTheCircle = 1,
        CatchTheDroplet = 2,
        Sudoku = 3,
        SpaceGame = 101,
        CityDefense = 102
    }
}