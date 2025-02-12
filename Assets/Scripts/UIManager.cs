using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainmenu;
    public GameObject pausemenu;
    public GameObject gameplayUI;


    public void EnableMainMenu()
    {
        TurnoffAll();
        mainmenu.SetActive(true);

    }

    public void EnablePause()
    {
        TurnoffAll();
        pausemenu.SetActive(true);

    }

    public void GamePlayUI()
    {
        TurnoffAll();
        gameplayUI.SetActive(true);
    }

    public void TurnoffAll()
    {
        mainmenu.SetActive(false);
        pausemenu.SetActive(false);
        gameplayUI.SetActive(false);
    }

}
