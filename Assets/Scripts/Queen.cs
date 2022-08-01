using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Queen : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        // Base setup
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // Queen stuff
        int height = newPieceManager.board.height;
        mMovement = new Vector3Int(height-1, height-1, height-1);

        if (!SceneManager.GetActiveScene().name.Contains("Beige"))
        {
            if (newTeamColor.Equals(Color.white))
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("white_queen");
            }
            else
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("black_queen");
            }
        }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Queen");
        }

    }
}
