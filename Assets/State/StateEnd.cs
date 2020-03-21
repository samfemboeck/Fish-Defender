using UnityEngine;
using UnityEngine.InputSystem;

public class StateEnd : MonoBehaviour
{
    [SerializeField]
    Screen title;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towerPlayers;

    [SerializeField]
    GameObjectSet collectibles;

    private GameObject[] winner;
    private int highestFishScore;
    

    private void Start()
    {
        winner = new GameObject[fishes.Count];

        fishes.RemoveAll();
        towerPlayers.RemoveAll();
        collectibles.RemoveAll();

        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Keyboard.PressSpace.performed += OnPressSpace;
    }

    public void OnPressSpace(InputAction.CallbackContext ctx)
    {
        ScreenManager.Instance.ChangeToScreen(title);
    }

    private GameObject[] GetWinner()
    {
        GameObject[] winnerFishes;

        int fishScore = GetHighestFishScore(out winnerFishes);
        int towerScore = towerPlayers.items[0].GetComponent<TowerScore>().Score;

        if (towerScore <= 0 || fishScore >= 10)
        {
            return winnerFishes;
        }
        else
        {
            GameObject[] winnerTower = { towerPlayers.items[0] };
            return winnerTower;
        }
    }

    private int GetHighestFishScore(out GameObject[] winner)
    {
        GameObject[] winnerFishes = new GameObject[fishes.Count];
        int nextIndex = 0;
        int winnerScore = -1;

        foreach (GameObject fish in fishes.items)
        {
            int fishScore = fish.GetComponent<FishScore>().Score;
            if (fishScore > winnerScore)
            {
                winnerFishes[nextIndex] = fish;
                winnerScore = fishScore;
                nextIndex++;
            }
        }

        winner = winnerFishes;
        return winnerScore;
    }
}
