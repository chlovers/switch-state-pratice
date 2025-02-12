using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public GameManager gameManager;
    // Enum representing different game states
    public enum GameState
    {
        MainMenu_State,   // The game is at the main menu
        Gameplay_State,   // The game is actively being played
        Paused_State      // The game is paused
    }


    // Property to store the current game state, accessible publicly but modifiable only within this class
    public GameState currentState { get; private set; }

    // Debugging variables to store the current and last game state as strings for easier debugging in the Inspector
    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

  

    public void Start()
    {
        // Set the initial state of the game to Main Menu when the game starts
        ChangeState(GameState.MainMenu_State);
    }

    // Method to change the current game state
    public void ChangeState(GameState newState)
    {
        // Store the current state as the last state before changing it
        lastStateDebug = currentState.ToString();

        // Assign the new state to currentState
        currentState = newState;

        // Call a function to handle any specific actions triggered by the state change
        HandleStateChange(newState);

        // Store the new state in a string variable for debugging purposes
        currentStateDebug = currentState.ToString();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeState(GameState.MainMenu_State);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (currentState == GameState.Gameplay_State || currentState == GameState.Paused_State))
        {
            if (currentState == GameState.Paused_State)
            {
                ChangeState(GameState.Gameplay_State);
            }
            else
            {
                ChangeState(GameState.Paused_State);
            }
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeState(GameState.Gameplay_State);
        }
    }


    // Handles any specific actions that need to occur when switching to a new state
    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu_State:
                Debug.Log("Switched to MainMenu State");
                Time.timeScale = 0;
                gameManager.iManager.EnableMainMenu();
                Cursor.visible = true;
                // TODO: Add logic for when the game enters the Main Menu (e.g., show UI)
                break;

            case GameState.Gameplay_State:
                Debug.Log("Switched to Gameplay State");
                // TODO: Add logic for starting/resuming the game (e.g., enable player movement)
                Time.timeScale = 1;
                gameManager.iManager.GamePlayUI();
                Cursor.visible = false;
                break;

            case GameState.Paused_State:
                Debug.Log("Switched to Paused State");
                // TODO: Add logic for pausing the game (e.g., stop player movement, show pause menu)
                Time.timeScale = 0;
                gameManager.iManager.EnablePause();
                Cursor.visible = true;
                break;
        }
    }

    public void playbutton()
    {
        ChangeState(GameState.Gameplay_State);

    }

    public void backtomenu()
    {

        ChangeState(GameState.MainMenu_State);
    }



}