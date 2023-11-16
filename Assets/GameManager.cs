using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public class GameManager
{
    public GameSuccessState successState { get; private set; }

    private Game currentGame;

    private GameObject objectsParent;
    
    public int gameCount { get; private set; }

    public GameManager()
    {
        successState = GameSuccessState.Null;
        objectsParent = new GameObject("GameObjects");
        gameCount = 0;
    }

    public GameSuccessState GetSuccessState()
    {
        return currentGame.GetSuccessState();
    }

    public void StartGame()
    {
        GameName gameName = GameName.CityDefense;

        switch (gameName)
        {
            case GameName.SquareTheCircle:
                currentGame = new SquareTheCircle(objectsParent);
                break;
            case GameName.CatchTheDroplet:
                currentGame = new CatchTheDroplet(objectsParent);
                break;
            case GameName.Sudoku:
                currentGame = new Sudoku(objectsParent);
                break;
            case GameName.SpaceGame:
                currentGame = new SpaceGame(objectsParent);
                break;
            case GameName.CityDefense:
                currentGame = new CityDefense(objectsParent);
                break;
            default:
                Debug.LogError("Unknown Game Selected");
                currentGame = new SquareTheCircle(objectsParent);
                break;
        }
        
        currentGame.SetUpGame();
    }

    public void EndGame()
    {
        if (currentGame != null)
        {
            currentGame.CleanUpGame();
        }
    }

    public void IncrementGameCount()
    {
        gameCount++;
    }

    public GameName GetCurrentGameName()
    {
        return currentGame.gameName;
    }
}

public enum GameSuccessState
{
    Null = 0,
    Success = 1,
    Failure = 2
}