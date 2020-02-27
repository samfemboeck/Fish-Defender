using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    [SerializeField]
    DeviceManager deviceManager;

    [SerializeField]
    Image[] fishSprites;

    [SerializeField]
    Text fishesJoinedText;

    //Private Var
    private int currentGamepads = -1;    //RM used for checking whether gamepads have changed

    void Start()
    {
        deviceManager = new DeviceManager();
        deviceManager.OnGamepadChange += OnGamepadChange;
        //OnGamepadChange(null, null);
    }

    //void Update()
    void OnGamepadChange(object sender, EventArgs e)
    {
        int gamepads = deviceManager.gamepads.Count;

        //Only iterate all UI images if gamepads have changed
        //if (gamepads == currentGamepads)
            //return;

        //Iterate all UI images and check whether they should be visible
        for (int i = 0; i < fishSprites.Length; i++)
        {
            if (i < gamepads)
                fishSprites[i].enabled = true;
            else
                fishSprites[i].enabled = false;
        }

        //Update displayed text
        if (gamepads == 1)
            fishesJoinedText.text = gamepads + " fish joined";
        else
            fishesJoinedText.text = gamepads + " fishes joined";
    }

    public void OnPlayerSwitch()
    {
        //TODO
    }
}
