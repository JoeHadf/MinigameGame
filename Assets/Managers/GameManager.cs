using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class GameManager
{
    private Game currentGame;

    private GameObject objectsParent;
    
    public int gameCount { get; private set; }

    public GameManager()
    {
        objectsParent = new GameObject("GameObjects");
        gameCount = 0;
    }

    public bool IsSuccess()
    {
        return currentGame.IsSuccess();
    }

    public void StartGame()
    {
        GameName name;
        if (gameCount % 10 == 0 && gameCount != 0)
        {
            name = GameInformation.GetBossGame();
        }
        else
        {
            name = GameInformation.GetRegularGame();
        }

        switch (name)
        {
            case GameName.SquareTheCircle:
                currentGame = new SquareTheCircle();
                break;
            case GameName.CatchTheDroplet:
                currentGame = new CatchTheDroplet();
                break;
            case GameName.Sudoku:
                currentGame = new Sudoku();
                break;
            case GameName.FlySwat:
                currentGame = new FlySwat();
                break;
            case GameName.SpaceGame:
                currentGame = new SpaceGame();
                break;
            case GameName.CityDefense:
                currentGame = new CityDefense();
                break;
            default:
                Debug.LogError("Unknown Game Selected");
                currentGame = new SquareTheCircle();
                break;
        }
        
        currentGame.SetUpGame();
    }

    public void EndGame()
    {
        ObjectSpawner.Instance.ClearObjects();
    }
    
    public void StartNextLevel()
    {
        IncrementGameCount();
        
        DifficultyType difficultyType = GetDifficultyTypeToIncrease();
        if (difficultyType != DifficultyType.Null)
        {
            IncreaseDifficulty(difficultyType);
        }
    }

    private void IncrementGameCount()
    {
        gameCount++;
    }

    private DifficultyType GetDifficultyTypeToIncrease()
    {
        DifficultyType difficultyType;
        
        if (gameCount % 10 == 5)
        {
            if (gameCount % 20 == 15 && gameCount <= (GameLevel.numberOfLevelIncreases * 20) + 15)
            {
                difficultyType = DifficultyType.Level;
            }
            else
            {
                difficultyType = DifficultyType.Speed;
            }
        }
        else
        {
            difficultyType = DifficultyType.Null;
        }

        return difficultyType;

    }

    private void IncreaseDifficulty(DifficultyType type)
    {
        switch (type)
        {
            case DifficultyType.Speed:
                GameSpeed.IncreaseGameSpeed();
                break;
            case DifficultyType.Level:
                GameLevel.IncreaseGameLevel();
                break;
        }
    }

    public float GetCurrentGameTime()
    {
        return currentGame.data.gameTime.GetTime();
    }

    private enum DifficultyType
    {
        Null = 0,
        Speed = 1,
        Level = 2
    }
}