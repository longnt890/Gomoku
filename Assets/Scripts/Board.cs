using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public int row;
    public int column;

    public GameObject cellPrefab;

    public Transform board;
    public GridLayoutGroup girdLayout;

    public string currentTurn = "x";
    private string[,] matrix;

    public int boardSize;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        matrix = new string[boardSize + 1, boardSize + 1];
        
        girdLayout.constraintCount = boardSize;

        CreateBoard();
    }

    private void CreateBoard()
    {
        for(int i = 1; i <= boardSize; i++)
        {
            for(int j = 1; j <= boardSize; j++)
            {
                GameObject cellTransform =  Instantiate(cellPrefab, board);
                Cell cell = cellTransform.GetComponent<Cell>();
                cell.row = i;
                cell.column = j;
                matrix[i, j] = "";
            }
        }
    }

    public bool Check(int row, int column)
    {
        matrix[row, column] = currentTurn;

        bool result = false;
        int count = 0;

        // Check horizontal
        for (int i = column - 1; i >= 1; i--) // Left
        {
            if (matrix[row, i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = column + 1; i <= boardSize; i++) // Right
        {
            if (matrix[row, i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }

        count = 0;

        // Check vertical
        for (int i = row - 1; i >= 1; i--) // Up
        {
            if (matrix[i, column] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = row + 1; i <= boardSize; i++) // Down
        {
            if (matrix[i, column] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }

        count = 0;

        // Check diagonals
        // Diagonal from top-left to bottom-right
        for (int i = 1; row - i >= 1 && column - i >= 1; i++)
        {
            if (matrix[row - i, column - i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = 1; row + i <= boardSize && column + i <= boardSize; i++)
        {
            if (matrix[row + i, column + i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }

        count = 0;

        // Diagonal from top-right to bottom-left
        for (int i = 1; row - i >= 1 && column + i <= boardSize; i++)
        {
            if (matrix[row - i, column + i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = 1; row + i <= boardSize && column - i >= 1; i++)
        {
            if (matrix[row + i, column - i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        if (count + 1 >= 5)
        {
            result = true;
        }

        return result;
    }


}
