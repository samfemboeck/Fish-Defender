using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int connectedGamepads = 0;
    public bool isGameRunning = false;
    string canvasText = "";
    public ObjectSpawner objectSpawner;
    public Canvas canvas;
    public Text menuText;

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning)
        {
            int gamepads = 0;

            foreach (var device in InputSystem.devices)
            {
                if (device is Gamepad)
                {
                    gamepads++;
                }
            }

            this.connectedGamepads = gamepads;
            menuText.text = this.connectedGamepads + " Fishes joined";
        }
    }

    public void OnPressSpace()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameRunning = true;
        canvas.enabled = false;
        
        for (int i = 0; i < connectedGamepads; i++)
        {
            objectSpawner.SpawnPlayer();
        }
    }

    public void EndGame(int id)
    {
        isGameRunning = false;
        // show End Screen
    }
}
