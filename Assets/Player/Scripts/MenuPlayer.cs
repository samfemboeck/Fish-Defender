using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

public class MenuPlayer : MonoBehaviour, IHavePlayerInput
{
    [SerializeField]
    GameObject fishPlayerPrefab;

    [SerializeField]
    GameObject towerPlayerPrefab;

    [SerializeField]
    GameEvent OnPlayerLock;

    [SerializeField]
    GameEvent OnPlayerSwitch;

    public bool isFish;

    public PlayerInput PlayerInput { get; set; }

    private void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.playerControls.MenuPlayer.SwitchRole.performed += OnSwitchRole;        
        PlayerInput.playerControls.MenuPlayer.LockRole.performed += OnLockRole;
    }

    public void OnLockRole(InputAction.CallbackContext obj)
    {
        PlayerInput.Disable();
        OnPlayerLock.Raise(gameObject);
    }

    public void OnSwitchRole(InputAction.CallbackContext ctx)
    {
        isFish = !isFish;
        OnPlayerSwitch.Raise(gameObject);
    }

    public GameObject GetRolePrefab()
    {
        if (isFish)
            return fishPlayerPrefab;
        else
            return towerPlayerPrefab;
    }
}
