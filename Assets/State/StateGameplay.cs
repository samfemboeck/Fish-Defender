using System;
using UnityEngine;
using UnityEngine.Events;

public class StateGameplay : MonoBehaviour
{
    [SerializeField]
    GameObject collectibleSpawnerPrefab;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towers;

    [SerializeField]
    Screen end;

	[SerializeField]
	private int timerSeconds;

	[SerializeField]
	private GameEvent onTimerUpdate;

    [SerializeField]
    int fishInstaWin = 10;

    private void Start()
    {
        GameObject spawner = Instantiate(collectibleSpawnerPrefab);
        spawner.transform.SetParent(transform);
        Invoke("SpawnTowerProjectiles", 3);
		InvokeRepeating("UpdateTimer", 1, 1);
    }

	private void OnDestroy()
	{
		CancelInvoke("UpdateTimer");
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

    public void OnFishScoreUpdate(GameObject fish)
    {
        //TODO
        if (fish.GetComponent<FishScore>().Score >= fishInstaWin)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    public void OnFishKill(GameEvent gameEvent)
    {
        if (fishes.Count <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }
}
