using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class TowerController : PlayerController
{
    public GameObject[] towers;
    Tower curTower;
    GameObject curProjectile;
    int curTowerIndex;

    private void Start()
    {
        inputActions.Tower.MoveStick.performed += ctx => MoveLeftStick(ctx);
        inputActions.Tower.PressDPad.performed += ctx => PressDPad(ctx);
        print(towers.Length);
        SelectTower(0);
    }

    private void PressDPad(CallbackContext ctx)
    {
        Vector2 value = ctx.ReadValue<Vector2>();
        int xDirection = (int) value.x;
        int index = curTowerIndex + xDirection;
        SelectTower(index);
    }

    void SelectTower(int index)
    {
        int nextIndex = curTowerIndex + index;

        if (nextIndex >= towers.Length)
            nextIndex = 0;
        else if (nextIndex < 0)
            nextIndex = towers.Length - 1;

        // TODO Spawn TowerPlayer after Tower.SpawnBall()
        curTowerIndex = nextIndex;
        curProjectile = towers[curTowerIndex].GetComponent<Tower>().ActiveProjectile;
    }

    private void MoveLeftStick(CallbackContext ctx)
    {
        Vector2 value = ctx.ReadValue<Vector2>();
        var projectilePos = curProjectile.transform.position;
        Vector3 linePos = new Vector3(projectilePos.x + value.x, projectilePos.y, projectilePos.z + value.y);
        Tower tower = towers[curTowerIndex].GetComponent<Tower>();
        curProjectile = tower.ActiveProjectile;
        curProjectile.GetComponent<LineRenderer>().SetPosition(0, curProjectile.transform.position);
        curProjectile.GetComponent<LineRenderer>().SetPosition(1, linePos);
    }
}