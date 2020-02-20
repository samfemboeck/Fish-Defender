using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int connectedGamepads = 0;
    public bool isGameRunning = false;
    public Scoreboard scoreboard;
    string canvasText = "";
    public ObjectSpawner objectSpawner;
    public GameObject menuScreen;
    public Text menuText;
    private IGameState gameState;
    public GameMenuState gameMenuState;
    public GameRunningState gameRunningState;
    public GameEndedState gameEndedState;
    public Player[] activePlayers;

    private void Awake()
    {
        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Scoreboard>();
        gameMenuState = new GameMenuState(this);
        gameRunningState = new GameRunningState(this);
        gameEndedState = new GameEndedState(this);
        SetGameState(gameMenuState);
    }

    void Update()
    {
        gameState.Update();
    }

    public void SetGameState(IGameState gameState) 
    {
        this.gameState = gameState;
        this.gameState.Init();
    }

    public void OnPressSpace()
    {
        gameState.OnPressSpace();
    }

    public void EndGame()
    {
        isGameRunning = false;
        Debug.Log("Game ended");
        // show End Screen
    }
}
