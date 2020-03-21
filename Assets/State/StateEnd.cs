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

    public bool fishWin;
    public Color[] winnerColor;
    

    private void Start()
    {
        GetWinner();

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

    private void GetWinner()
    {
        GameObject[] winnerFishes = new GameObject[fishes.Count];

        int fishScore = GetHighestFishScore(ref winnerFishes);
        int towerScore = towerPlayers.items[0].GetComponent<TowerScore>().Score;

        //Fishes win
        if (towerScore <= 0 || fishScore >= 10)
        {
            winnerColor = new Color[fishes.Count];
            for (int i=0; i<winnerFishes.Length; i++)
            {
                print("debug fish: " + i + " " + winnerFishes.Length);
                if (winnerFishes[i] == null) break;
                winnerColor[i] = winnerFishes[i].GetComponent<PlayerColor>().color;
            }
            fishWin = true;
        }
        //Tower wins
        else
        {
            fishWin = false;
        }
        
        print("Debug fishWin: " + fishWin);
    }

    private int GetHighestFishScore(ref GameObject[] winner)
    {
        int nextIndex = 0;
        int winnerScore = -1;

        foreach (GameObject fish in fishes.items)
        {
            int fishScore = fish.GetComponent<FishScore>().Score;
            if (fishScore >= winnerScore)
            {
                winner[nextIndex] = fish;
                winnerScore = fishScore;
                nextIndex++;
            }
        }

        return winnerScore;
    }
}
