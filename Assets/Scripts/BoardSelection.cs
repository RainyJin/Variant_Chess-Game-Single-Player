using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BoardSelection : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown boardCol;
    public TMP_InputField rankNum;
    

    public void Starts()
    {

        string input = rankNum.text;
        int rankNumber = 8;
        try
        {
            rankNumber = int.Parse(input);
        }
        catch (System.Exception e)
        {
            SceneManager.LoadScene("GameScene");
        }

        if (boardCol.options[boardCol.value].text.Equals("Black & White"))
        {
            if (rankNumber == 6)
            {
                SceneManager.LoadScene("GameScene6");
            }
            else if (rankNumber == 7)
            {
                SceneManager.LoadScene("GameScene7");
            }
            else if (rankNumber == 9)
            {
                SceneManager.LoadScene("GameScene9");
            }
            else if (rankNumber == 10)
            {
                SceneManager.LoadScene("GameScene10");
            }
            else if (rankNumber == 11)
            {
                SceneManager.LoadScene("GameScene11");
            }
            else
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        

        if (boardCol.options[boardCol.value].text.Equals("Wooden"))
        {
            if (rankNumber == 6)
            {
                SceneManager.LoadScene("GameSceneBeige6");
            }
            else if (rankNumber == 7)
            {
                SceneManager.LoadScene("GameSceneBeige7");
            }
            else if (rankNumber == 9)
            {
                SceneManager.LoadScene("GameSceneBeige9");
            }
            else if (rankNumber == 10)
            {
                SceneManager.LoadScene("GameSceneBeige10");
            }
            else if (rankNumber == 11)
            {
                SceneManager.LoadScene("GameSceneBeige11");
            }
            else
            {
                SceneManager.LoadScene("GameSceneBeige");
            }
        }
    }

}
