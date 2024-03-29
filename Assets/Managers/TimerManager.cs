using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager
{
    private static TimerManager instance;
    
    public GameTimer gameTimer;
    public GameState currentState { get; private set; }

    private TimerManager()
    {
        GameObject timer = new GameObject("Timer");
        gameTimer = timer.AddComponent<GameTimer>();
        currentState = GameState.Null;
    }

    public static TimerManager GetInstance()
    {
        if (instance == null)
        {
            instance = new TimerManager();
        }

        return instance;
    }

    public void StartLoop()
    {
        currentState = GameState.PreGame;
        gameTimer.SetTimer(3);
    }

    public void IncrementState()
    {
        int nextValue = (int)currentState + 1;

        if (nextValue == 4)
        {
            nextValue = 1;
        }

        currentState = (GameState)nextValue;
    }

    public void EndGameEarly()
    {
        if (currentState == GameState.Game)
        {
            gameTimer.SetTimer(0);
        }
    }
}

public enum GameState
{
    Null = 0,
    PreGame = 1,
    Instruction = 2,
    Game = 3
}
