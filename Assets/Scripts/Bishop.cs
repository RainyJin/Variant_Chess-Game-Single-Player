using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bishop : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        // Base setup
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        // Bishop stuff
        int height = newPieceManager.board.height;
        mMovement = new Vector3Int(0, 0, height-1);


        if (!SceneManager.GetActiveScene().name.Contains("Beige"))
        {
            if (newTeamColor.Equals(Color.white))
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("white_bishop");
            }
            else
            {
                GetComponent<Image>().sprite = Resources.Load<Sprite>("black_bishop");
            }
        }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("T_Bishop");
        }


    }
}
