using UnityEngine;
using UnityEngine.UI;

public class StateGameplay : MonoBehaviour
{
    [SerializeField]
    GameObject collectibleSpawnerPrefab;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    Screen end;

    ScreenManager screenManager;

    private void Start()
    {
        screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();

        GameObject spawner = Instantiate(collectibleSpawnerPrefab);
        spawner.transform.SetParent(transform);
    }

    public void OnTowerScoreUpdate(GameObject tower)
    {
        if (tower.GetComponent<TowerScore>().Score <= 0)
            screenManager.ChangeToScreen(end);
    }

    public void OnFishKill(GameObject obj)
    {
        if (fishes.Count <= 0)
            screenManager.ChangeToScreen(end);
    }
}
