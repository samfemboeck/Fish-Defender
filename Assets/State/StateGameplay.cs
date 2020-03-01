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

    private void Start()
    {
        GameObject spawner = Instantiate(collectibleSpawnerPrefab);
        spawner.transform.SetParent(transform);
    }

    public void OnTowerScoreUpdate(GameObject tower)
    {
        if (tower.GetComponent<TowerScore>().Score <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    public void OnFishKill(GameObject obj)
    {
        if (fishes.Count <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }
}
