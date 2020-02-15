using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public static int towerHealth = 10;
    public int[] playerScores;

    public void OnPlayerCollect(int id)
    {
        towerHealth -= 1;
        playerScores[id] += 1;

        //Update UI
        UiHandler.UpdateTowerUI(towerHealth);
        UiHandler.UpdateFishUI(id, playerScores[id]);
    }

    public void OnPlayerKill(int id)
    {
        // killed players have score -1
        playerScores[id] = -1;
    }
}
