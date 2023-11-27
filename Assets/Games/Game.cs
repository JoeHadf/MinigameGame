using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Games
{
    public abstract class Game
    {
        public GameData data { get; private set; }

        protected ObjectSpawner objectSpawner;

        protected Game(GameName name)
        {
            this.data = GameInformation.GetGameData(name);
            objectSpawner = ObjectSpawner.Instance;
        }

        public void SetUpGame()
        {
            switch (GameLevel.level)
            {
                case GameLevel.Level.Easy:
                    SetUpEasy();
                    break;
                case GameLevel.Level.Medium:
                    SetUpMedium();
                    break;
                case GameLevel.Level.Hard:
                    SetUpHard();
                    break;
                default:
                    Debug.Log("Unknown game level to set up");
                    SetUpEasy();
                    break;
            }
        }

        protected abstract void SetUpEasy();

        protected abstract void SetUpMedium();

        protected abstract void SetUpHard();

        public abstract bool IsSuccess();
    }
}