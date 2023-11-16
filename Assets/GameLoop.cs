using System;
using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;
using static System.Math;

public class GameLoop : MonoBehaviour
{
    LifeManager lifeManager;
    TimerManager timerManager; 
    GameManager gameManager;

    private const float preGameTime = 3;
    private const float instructionTime = 1;
    private const float gameTime = 20;

    private void Awake()
    {
        lifeManager = new LifeManager();
        timerManager = new TimerManager();
        gameManager = new GameManager();
    }

    void Start()
    {
        timerManager.StartLoop();
    }

    void Update()
    {
        if (timerManager.gameTimer.hasFinished)
        {
            timerManager.IncrementState();
            OnGameStateChanged();
        }
    }

    private void OnGUI()
    {
        int roundUp = (int) Math.Ceiling(timerManager.gameTimer.currentTime);
        GUI.Label(new Rect(10, 10, 100, 20), roundUp.ToString());

        if (timerManager.currentState == GameState.PreGame)
        {
            GUI.Label(new Rect(100, 10, 400, 80), gameManager.gameCount.ToString());
        }
    }

    private void OnGameStateChanged()
    {
        switch (timerManager.currentState)
        {
            case GameState.PreGame:
                OnEnterPreGame();
                break;
            case GameState.Instruction:
                OnEnterInstruction();
                break;
            case GameState.Game:
                OnEnterGame();
                break;
            default:
                break;
        }
    }

    private void OnEnterPreGame()
    {
        GameSuccessState successState = gameManager.GetSuccessState();
        gameManager.EndGame();
        if (successState != GameSuccessState.Success)
        {
            lifeManager.LoseLife();
            if (lifeManager.lifeCount <= 0)
            {
                timerManager.gameTimer.isLocked = true;
            }
        }
        else
        {
            gameManager.IncrementGameCount();
        }
        lifeManager.ShowLives();
        timerManager.gameTimer.SetTimer(preGameTime);
    }

    private void OnEnterInstruction()
    {
        lifeManager.HideLives();
        timerManager.gameTimer.SetTimer(instructionTime);
    }

    private void OnEnterGame()
    {
        gameManager.StartGame();
        timerManager.gameTimer.SetTimer(GetGameTime(gameManager.GetCurrentGameName()));
    }

    private float GetGameTime(GameName name)
    {
        switch (name)
        {
            case GameName.SquareTheCircle:
                return 7;
            case GameName.CatchTheDroplet:
                return 5;
            case GameName.Sudoku:
                return 5;
            case GameName.SpaceGame:
                return 20;
            case GameName.CityDefense:
                return 20;
            default:
                return 1;
        }
    }
}
