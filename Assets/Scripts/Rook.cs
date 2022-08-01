using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rook : BasePiece
{
    [HideInInspector]
    public Cell mCastleTriggerCell = null;
    private Cell mCastleCell = null;

    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        // Base setup
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // Rook stuff
        int height = newPieceManager.board.height;
        mMovement = new Vector3Int(height, height, 0);

        if (!SceneManager.GetActiveScene().name.Contains("Beige"))
        {
            if (newTeamColor.Equals(Color.white))
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("white_rook");
            }
            else
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("black_rook");
            }
        }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Rook");
        }


    }

    public override void Place(Cell newCell)
    {
        // After being placed, set castle, need current cell
        base.Place(newCell);

        // Trigger cell
        int triggerOffset = mCurrentCell.mBoardPosition.x < 4 ? 2 : -1;
        mCastleTriggerCell = SetCell(triggerOffset);

        // Castle cell
        int castleOffset = mCurrentCell.mBoardPosition.x < 4 ? 3 : -2;
        mCastleCell = SetCell(castleOffset);
    }

    public void Castle()
    {
        // Set new target
        mTargetCell = mCastleCell;

        // Actually move
        Move();
    }

    private Cell SetCell(int offset)
    {
        // New position
        Vector2Int newPosition = mCurrentCell.mBoardPosition;
        newPosition.x += offset;

        // Return
        return mCurrentCell.mBoard.mAllCells[newPosition.x, newPosition.y];
    }
}
