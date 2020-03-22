using UnityEngine;
using UnityEngine.UI;

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
    int fishInstaWin = 10;

    private void Start()
    {
        GameObject spawner = Instantiate(collectibleSpawnerPrefab);
        spawner.transform.SetParent(transform);
        Invoke("SpawnTowerProjectiles", 3);
    }

    private void SpawnTowerProjectiles()
    {
        new TowerDecorator(towers).SpawnProjectiles();
    }

    public void OnTowerScoreUpdate(GameObject tower)
    {
        if (tower.GetComponent<TowerScore>().Score <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    public void OnFishScoreUpdate(GameObject fish)
    {
        //TODO
        if (fish.GetComponent<FishScore>().Score >= fishInstaWin)
            ScreenManager.Instance.ChangeToScreen(end);
    }

    public void OnFishKill(GameObject obj)
    {
        if (fishes.Count <= 0)
            ScreenManager.Instance.ChangeToScreen(end);
    }
}
