using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class StateTitle : MonoBehaviour
{
    [SerializeField]
    Screen selectRole;
    
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.playerControls.Keyboard.PressSpace.performed += OnPressSpace;

        GetComponent<AudioSource>().Play();
    }

    private void OnDestroy()
    {
        playerInput.Disable();
    }

    public void OnPressSpace(InputAction.CallbackContext obj)
    {
        GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>().ChangeToScreen(selectRole);
    }
}
