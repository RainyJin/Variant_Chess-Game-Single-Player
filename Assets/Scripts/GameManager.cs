using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Board mBoard;

    public PieceManager mPieceManager;

    // Start is called before the first frame update
    void Start()
    {
        // Create the board
        if (SceneManager.GetActiveScene().name.Contains("Beige"))
        {
            mBoard.Create(new Color32(135, 80, 63, 255));
        }
        else
        {
            mBoard.Create(new Color32(34, 36, 43, 255));
        }

        // Create the pieces
        mPieceManager.Setup(mBoard);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos.x + " and " + mousePos.y);

        }*/
    }
}
