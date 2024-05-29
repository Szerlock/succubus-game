using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public enum GameState
   {
        Gameplay,
        Paused,
        GameOver
   }

    //Store the current state of the game
   public GameState currentState;
   public GameState previousState;

    void Update()
    {
        TestSwitchState();
        switch (currentState)
        {
            case GameState.Gameplay:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
            default:
            Debug.LogWarning("Check State Lil Bro");
                break;
        }
    }

    void TestSwitchState()
    {
        if(Input.GetKeyDown(KeyCode.E))
            currentState++;
        else if(Input.GetKeyDown(KeyCode.Q))
            currentState--;
    }

    public void PauseGame()
    {
        if(currentState != GameState.Paused){
            currentState = GameState.Paused;
            Time.timeScale = 0f;
            Debug.Log("Its paused lil bro");
        }
    }

    public void Resume()
    {
        if(currentState == GameState.Paused){
            currentState = previousState;
            Time.timeScale = 1f;
            Debug.Log("Game resumed");
        }
    }
}
