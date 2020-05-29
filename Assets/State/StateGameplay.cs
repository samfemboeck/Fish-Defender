using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class StateGameplay : MonoBehaviour
{
    [SerializeField]
    GameObject collectibleSpawnerPrefab;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towers;

    [SerializeField]
    GameObjectSet playerInputs;

    [SerializeField]
    Screen end;

	[SerializeField]
	private int timerSeconds;

	[SerializeField]
	private GameEvent onTimerUpdate;

    [SerializeField]
    int fishInstaWin = 10;

    // when a new gamepad connects, try to reconnect to the first gamepad that disconnected
    Queue<PlayerInput> disconnectedInputs = new Queue<PlayerInput>();
    DeviceManager deviceManager;

    private void Start()
    {
        GameObject spawner = Instantiate(collectibleSpawnerPrefab);
        spawner.transform.SetParent(transform);
        Invoke("SpawnTowerProjectiles", 3);
		InvokeRepeating("UpdateTimer", 1, 1);
        deviceManager = new DeviceManager();
        deviceManager.OnGamepadRemoved += DisconnectGamepad;
        deviceManager.OnGamepadAdded += ReconnectGamepad;
    }

    void DisconnectGamepad(Gamepad gamepad)
    {
        foreach (GameObject gameObject in playerInputs.items)
        {
            PlayerInput playerInput = gameObject.GetComponent<PlayerInput>();

            if (playerInput.device.deviceId == gamepad.deviceId)
            {
                disconnectedInputs.Enqueue(playerInput);
                break;
            }
        }
    }

    void ReconnectGamepad(Gamepad gamepad)
    {
        if (disconnectedInputs.Count == 0) return;

        PlayerInput playerInput = disconnectedInputs.Dequeue();
        playerInput.RestrictToDevice(gamepad);
    }

    private void OnDestroy()
    {
        CancelInvoke("UpdateTimer");
        deviceManager.OnGamepadRemoved -= DisconnectGamepad;
        deviceManager.OnGamepadAdded -= ReconnectGamepad;
    }

    private void UpdateTimer()
    {
        onTimerUpdate.Raise(--timerSeconds);
        if (timerSeconds <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    private void SpawnTowerProjectiles()
    {
        new TowerDecorator(towers).SpawnProjectiles();
    }

    public void OnTowerScoreUpdate(GameEvent gameEvent)
    {
        GameObject tower = gameEvent.GameObject;
        if (tower.GetComponent<TowerScore>().Score <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    public void OnFishScoreUpdate(GameEvent gameEvent)
    {
        //TODO
        GameObject fish = gameEvent.GameObject;
        if (fish.GetComponent<FishScore>().Score >= fishInstaWin)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    public void OnFishKill(GameEvent gameEvent)
    {
        if (fishes.Count <= 1)
            ScreenManager.Instance.ChangeToScreen(end);
    }
}
