using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UITitle : MonoBehaviour
{
    /*
     * UI Title
     * This class handles functionaltiy for the title UI.
     */

    [SerializeField]
    DeviceManager deviceManager;

    [SerializeField]
    Image[] playerDisplay;  //RM contains the placed images on the title canvas

    [SerializeField]
    Sprite fishSprite;

    [SerializeField]
    Sprite towerSprite;

    [SerializeField]
    Text fishesJoinedText;  //RM reference to the text on the title canvas that displays player count

    [SerializeField]
    GameObjectSet menuPlayers;  //RM contains all menu players


    void Start()
    {
        deviceManager = new DeviceManager();
        deviceManager.OnGamepadChange += OnGamepadChange;
        OnGamepadChange(null, null);    //RM initially call OnGamepadChange to make sure everything is hidden at start
    }
    
    //Updates title screen when gamepad (dis-)connects
    void OnGamepadChange(object sender, EventArgs e)    //RM sender is the deviceManager that raised the event
    {
        print("gamepad changed");

        int gamepads = deviceManager.gamepads.Count;
        
        //Iterate all UI images and check whether they should be visible
        for (int i = 0; i < playerDisplay.Length; i++)
        {
            if (i < gamepads)
            {
                //Enable image
                playerDisplay[i].enabled = true;
                playerDisplay[i].GetComponent<Animator>().Play("Fish_wiggle", 0, UnityEngine.Random.value);
                //Get player color
                Color playerColor = menuPlayers.items[i].gameObject.GetComponent<PlayerColor>().color;
                print("player color" + playerColor.ToString());
                print("sprite color" + playerDisplay[i].color);
                //Set sprite color
                playerDisplay[i].color = playerColor;
                print("sprite color" + playerDisplay[i].color);
            }
            else
                playerDisplay[i].enabled = false;
        }

        //Update displayed text
        if (gamepads == 1)
            fishesJoinedText.text = gamepads + " fish joined";
        else
            fishesJoinedText.text = gamepads + " fishes joined";
    }

    //Updates player image when they change role
    public void OnPlayerSwitch(GameObject obj)
    {
        //TODO
        //Get menuPlayer index from menuPlayers.items
        //Check whether menuPlayer is fish
        //Change sprite in image with same index
    }
}
