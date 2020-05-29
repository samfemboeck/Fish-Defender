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

    [SerializeField]
    GameObjectSet playerInputs;

    [SerializeField]
    GameObject towerScoreObject;

    public bool fishWin;
    public Color[] winnerColor;

    AudioManager audio;
    

    private void Start()
    {
        GetWinner();

        FindObjectOfType<UIEnd>().SetWinnerSprite(this);

        fishes.RemoveAll();
        towerPlayers.RemoveAll();
        collectibles.RemoveAll();
        playerInputs.RemoveAll();

        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Keyboard.PressSpace.performed += OnPressSpace;
        playerInput.playerControls.Gamepad.PressButtonEast.performed += OnPressSpace;

        audio = FindObjectOfType<AudioManager>();
        audio.Play("MatchStarts");
    }

    public void OnPressSpace(InputAction.CallbackContext ctx)
    {
        ScreenManager.Instance.ChangeToScreen(title);
    }

    private void GetWinner()
    {
        GameObject[] winnerFishes = new GameObject[fishes.Count];
        int fishCount;

        int fishScore = GetHighestFishScore(ref winnerFishes, out fishCount);
        int towerScore = towerScoreObject.GetComponent<TowerScore>().Score;

        //Fishes win
        if (towerScore <= 0 || fishScore >= 10)
        {
            winnerColor = new Color[fishCount];
            for (int i=0; i<winnerFishes.Length; i++)
            {
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
    }

    private int GetHighestFishScore(ref GameObject[] winner, out int winnerCount)
    {
        int nextIndex = 0;
        int winnerScore = int.MinValue;

        foreach (GameObject fish in fishes.items)
        {
            int fishScore = fish.GetComponent<FishScore>().Score;
            if (fishScore > winnerScore)
            {
                for (int i=0; i<winner.Length; i++)
                {
                    winner[i] = null;
                }
                winner[nextIndex++] = fish;
                winnerScore = fishScore;
            }
            else if (fishScore == winnerScore)
            {
                winner[nextIndex++] = fish;
            }
        }

        winnerCount = nextIndex;
        return winnerScore;
    }
}
