using UnityEngine;

public class StateEnd : MonoBehaviour
{
    [SerializeField]
    Screen selectRole;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towerPlayers;

    [SerializeField]
    GameObjectSet collectibles;

    private void Start()
    {
        fishes.RemoveAll();
        towerPlayers.RemoveAll();
        collectibles.RemoveAll();
    }

    public void OnPressSpace()
    {
        GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>().ChangeToScreen(selectRole);
    }
}
