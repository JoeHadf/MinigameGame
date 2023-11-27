using System.Collections;
using System.Collections.Generic;
using Games;
using UnityEngine;

public static class GameInformation
{
    private static List<GameName> regularGames = new List<GameName>();
    
    private static List<GameName> bossGames = new List<GameName>();

    private static Dictionary<GameName, GameData> gameDatas = new Dictionary<GameName, GameData>();
    
    static GameInformation()
    {
        CreateGameData(GameName.SquareTheCircle, GameType.Regular, 7);
        CreateGameData(GameName.CatchTheDroplet, GameType.Regular, 5);
        CreateGameData(GameName.Sudoku, GameType.Regular, 5);
        
        CreateGameData(GameName.SpaceGame, GameType.Boss, 20);
        CreateGameData(GameName.CityDefense, GameType.Boss, 20);
    }

    private static void CreateGameData(GameName name, GameType type, float time)
    {
        GameData data = new GameData(name, type, time);
        if (type == GameType.Regular)
        {
            regularGames.Add(name);
        }
        else
        {
            bossGames.Add(name);
        }
        
        gameDatas.Add(name, data);
    }

    public static GameName GetRegularGame()
    {
        int totalGameCount = regularGames.Count;
        int selectedGame = Random.Range(0, totalGameCount);

        return regularGames[selectedGame];
    }
    
    public static GameName GetBossGame()
    {
        int totalGameCount = bossGames.Count;
        int selectedGame = Random.Range(0, totalGameCount);

        return bossGames[selectedGame];
    }

    public static GameData GetGameData(GameName name)
    {
        return gameDatas[name];
    }
}

public enum GameName
{
    SquareTheCircle = 1,
    CatchTheDroplet = 2,
    Sudoku = 3,
    SpaceGame = 101,
    CityDefense = 102
}

public enum GameType
{
    Regular = 1,
    Boss = 2
}

public struct GameData
{
    public readonly GameName name;

    public readonly GameType type;

    public readonly EntityTime gameTime;

    public GameData(GameName name, GameType type, float time)
    {
        this.name = name;
        this.type = type;
        this.gameTime = new EntityTime(time);
    }
}