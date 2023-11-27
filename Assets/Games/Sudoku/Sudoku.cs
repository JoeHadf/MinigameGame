using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Games;
using UnityEngine;

public class Sudoku : Game
{
    private SudokuController sudokuController;

    private int missingNumber;

    private const float spacing = 1;
    
    public Sudoku() : base(GameName.Sudoku) { }
    
    protected override void SetUpEasy()
    {
        GameObject numberContainerObject = Resources.Load("Games/Sudoku/NumberContainer", typeof(GameObject)) as GameObject;
        NumberContainer numberContainer = numberContainerObject.GetComponent<NumberContainer>();

        List<int> sudokuNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> shuffledNumbers = sudokuNumbers.OrderBy(_ => Random.Range(0, 100)).ToList();

        ObjectSpawner objectSpawner = ObjectSpawner.Instance;

        int playerPosition = Random.Range(0, 9);

        for (int i = 0; i < 9; i++)
        {
            int quotient = (i / 3) - 1;
            int remainder = (i % 3) - 1;

            Vector3 placePosition = new Vector3((float)remainder * spacing, (float)quotient * spacing, 0);

            GameObject currentPlace = objectSpawner.Spawn("place" + (i + 1), placePosition);
            
            SpriteRenderer currentSpriteRenderer = currentPlace.AddComponent<SpriteRenderer>();
            if (i == playerPosition)
            {
                currentSpriteRenderer.sprite = numberContainer.GetSpriteFromNumber(0);

                sudokuController = currentPlace.AddComponent<SudokuController>();
                missingNumber = shuffledNumbers[i];
            }
            else
            {
                currentSpriteRenderer.sprite = numberContainer.GetSpriteFromNumber(shuffledNumbers[i]);
            }
        }
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
        if (missingNumber == sudokuController.currentNumber)
        {
            return true;
        }
        
        return false;
    }
}
