using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuController : MonoBehaviour
{
    private NumberContainer numberContainer;
    private SpriteRenderer spriteRenderer;

    public int currentNumber;
    void Awake()
    {
        GameObject numberContainerObject = Resources.Load("Games/Sudoku/NumberContainer", typeof(GameObject)) as GameObject; 
        numberContainer = numberContainerObject.GetComponent<NumberContainer>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        currentNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            string currentString = i.ToString();
            if(Input.GetKeyDown(currentString))
            {
                spriteRenderer.sprite = numberContainer.GetSpriteFromNumber(i);
                currentNumber = i;
            }
        }
    }
}
