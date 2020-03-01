using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
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
        //Listen for changes on the gamepads
        deviceManager = new DeviceManager();
        deviceManager.OnGamepadAdded += OnGamepadChange;
        deviceManager.OnGamepadRemoved += OnGamepadChange;

        OnGamepadChange(null);    //RM initially call OnGamepadChange to make sure everything is hidden at start
    }
    
    //Updates title screen when gamepad (dis-)connects
    void OnGamepadChange(Gamepad gamepad)    //RM sender is the deviceManager that raised the event
    {
        int gamepads = menuPlayers.items.Count;
        
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
                //Set sprite color
                playerDisplay[i].color = playerColor;
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
    //RM gets called by event from MenuPlayer
    public void OnPlayerSwitch(GameObject obj)
    {
        //TODO
        //Get menuPlayer index from menuPlayers.items
        //Check whether menuPlayer is fish
        //Change sprite in image with same index

        //Get player index
        int index = menuPlayers.items.IndexOf(obj);
        print("player index:" + index);

        if (obj.GetComponent<MenuPlayer>().isFish)
        {
            //Change to fish sprite and set color
            print("change to fish");
        }
        else
        {
            //Change to tower sprite (and set color?)
            print("change to tower");
        }
    }

    //Displays on the UI that a player locked their choice of role
    //RM gets called by event from MenuPlayer
    //RM at the moment simply stops the animation >_>
    public void OnPlayerLockRole(GameObject obj)
    {
        //Get player index
        //int index = menuPlayers.items.IndexOf(obj);
        //print("player index:" + index);

        //Stop animation
        //playerDisplay[index].GetComponent<Animator>().StopPlayback();
    }
}
