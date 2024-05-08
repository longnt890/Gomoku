
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject gameOverWindown;

    private Board board;

    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;

    private Transform canvas;

    private Button button;
    internal int row;
    internal int column;

    private void Awake()
    {
        image = GetComponent<Image>();

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        board = FindObjectOfType<Board>();
        canvas = FindObjectOfType<Canvas>().transform;
    }


    public void ChangeImage(string s)
    {
        if(s == "x")
        {
            image.sprite = xSprite;
        }
        else
        {
            image.sprite = oSprite;
        }
    }

    public void OnClick()
    {
        ChangeImage(board.currentTurn);
        if (board.Check(this.row, this.column))
        {
            GameObject winner = Instantiate(gameOverWindown, canvas);
            winner.GetComponent<GameOverWindown>().SetName(board.currentTurn.ToUpper() + "  Thang!!!");
        }
        
        if(board.currentTurn == "x")
        {
            board.currentTurn = "o";
        }
        else
        {
            board.currentTurn = "x";
        }
    }

}
