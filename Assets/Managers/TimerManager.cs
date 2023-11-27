using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager
{
    public GameTimer gameTimer;
    public GameState currentState { get; private set; }

    public TimerManager()
    {
        GameObject timer = new GameObject("Timer");
        gameTimer = timer.AddComponent<GameTimer>();
        currentState = GameState.Null;
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
}

public enum GameState
{
    Null = 0,
    PreGame = 1,
    Instruction = 2,
    Game = 3
}
