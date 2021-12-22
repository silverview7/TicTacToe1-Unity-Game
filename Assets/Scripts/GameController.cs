using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text winPlayerText;
    public Text winPlayerCode;
    public Text[] buttonList;
    private int currentSide;
    Player[] players = new Player[2];

    private struct Player
    {
        public Player(int setID, string setCode) 
        {
            id = setID;
            code = setCode;
        }
        public int id;
        public string code;
    }

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        currentSide = 0;
        Player player1 = new Player(0, "X");
        Player player2 = new Player(1, "O");
        players[0] = player1;
        players[1] = player2;
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return players[currentSide].code;
    }

    public bool hasWon()
    {
        bool won = false;
        //Rows
        if (buttonList[0].text == players[currentSide].code && buttonList[1].text == players[currentSide].code && buttonList[2].text == players[currentSide].code)
            won = true;
        else if (buttonList[3].text == players[currentSide].code && buttonList[4].text == players[currentSide].code && buttonList[5].text == players[currentSide].code)
            won = true;
        else if (buttonList[6].text == players[currentSide].code && buttonList[7].text == players[currentSide].code && buttonList[8].text == players[currentSide].code)
            won = true;

        //Columns
        if (buttonList[0].text == players[currentSide].code && buttonList[3].text == players[currentSide].code && buttonList[6].text == players[currentSide].code)
            won = true;
        else if (buttonList[1].text == players[currentSide].code && buttonList[4].text == players[currentSide].code && buttonList[7].text == players[currentSide].code)
            won = true;
        else if (buttonList[2].text == players[currentSide].code && buttonList[5].text == players[currentSide].code && buttonList[8].text == players[currentSide].code)
            won = true;

        //Diagonals
        if (buttonList[0].text == players[currentSide].code && buttonList[4].text == players[currentSide].code && buttonList[8].text == players[currentSide].code)
            won = true;
        else if (buttonList[2].text == players[currentSide].code && buttonList[4].text == players[currentSide].code && buttonList[6].text == players[currentSide].code)
            won = true;

        return won;
    }

    public void EndTurn()
    {
        if (hasWon())
        {
            gameOver();
        }

        if (currentSide == 0)
            currentSide = 1;
        else
            currentSide = 0;
    }

    public void gameOver()
    {
        gameOverPanel.SetActive(true);
        winPlayerText.text = "PLAYER " + currentSide.ToString() + " WON!";
        winPlayerCode.text = players[currentSide].code.ToString();
    }
}
