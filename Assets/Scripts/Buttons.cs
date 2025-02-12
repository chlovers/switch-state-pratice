using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public GameManager gamemanager;

    public void PlayButton()
    {
        gamemanager.gameState.playbutton();

    }

    public void QuitButton()
    {
        Application.Quit();

    }


    public void BackToMenuButton()
    {
        gamemanager.gameState.backtomenu();

    }


}
