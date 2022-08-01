using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum CellState
{
    None,
    Friendly,
    Enemy,
    Free,
    OutOfBounds
}
public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;

    [SerializeField] public int height;
    public Cell[,] mAllCells = new Cell[8, 8];

    public void Create(Color32 cellCol)
    {
        mAllCells = new Cell[8, height];
        for (int y = 0; y < height; y++)
        {
            #region Create
            for (int x = 0; x < 8; x++)
            {
                // Create the cell
                GameObject newCell = Instantiate(mCellPrefab, transform);

                // Position
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);
                
                if (height == 6)
                {
                    rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 140);
                }
                else if (height == 7)
                {
                    rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 90);
                }
                else if (height == 9)
                {
                    rectTransform.anchoredPosition = new Vector2((x * 90) + 85, (y * 90) + 40);
                    rectTransform.localScale -= new Vector3(0.1f, 0.1f, 0);
                }
                else if (height == 10)
                {
                    rectTransform.anchoredPosition = new Vector2((x * 80) + 120, (y * 80) + 40);
                    rectTransform.localScale -= new Vector3(0.2f, 0.2f, 0);
                }
                else if (height == 11)
                {
                    rectTransform.anchoredPosition = new Vector2((x * 75) + 140, (y * 75) + 15);
                    rectTransform.localScale -= new Vector3(0.25f, 0.25f, 0);
                }

                // Setup
                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
        #endregion

        #region Color
        for (int x = 0; x < 8; x += 2)
        {
            for (int y = 0; y < height; y++)
            {
                // Offset for every other line (if even, white; odd, black)
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;

                // Color
                mAllCells[finalX, y].GetComponent<Image>().color = cellCol;
            }
        }
        #endregion
    }


    public CellState ValidateCell(int targetX, int targetY, BasePiece checkingPiece)
    {
        // Bounds check
        if (targetX < 0 || targetX > 7)
            return CellState.OutOfBounds;

        if (targetY < 0 || targetY > height-1)
            return CellState.OutOfBounds;

        // Get cell
        Cell targetCell = mAllCells[targetX, targetY];

        // If the cell has a piece
        if (targetCell.mCurrentPiece != null)
        {
            // If friendly
            if (checkingPiece.mColor == targetCell.mCurrentPiece.mColor)
                return CellState.Friendly;

            // If enemy
            if (checkingPiece.mColor != targetCell.mCurrentPiece.mColor)
                return CellState.Enemy;
        }

        return CellState.Free;
    }
}