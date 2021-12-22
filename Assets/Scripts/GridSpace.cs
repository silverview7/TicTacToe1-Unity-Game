using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
    private GameController gamecontroller;

    public void setGameControllerReference(GameController controller)
    {
        gamecontroller = controller;
    }
    public void setSpace()
    {
        buttonText.text = gamecontroller.GetPlayerSide();
        button.interactable = false;
        gamecontroller.EndTurn();
    }
}
