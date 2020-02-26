using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    public Image Tower;
    private Image[] towerScore;

    public Image[] Fishes = new Image[8];
    private Image[][] fishScores;

    int maxTowerHealth = 10;
    int maxFishPoints = 10;
    
    private void Awake()
    {
        //Get Tower Point images
        towerScore = Tower.GetComponentsInChildren<Image>();

        //Get Fish point images
        fishScores = new Image[Fishes.Length][];
        for (int i=0; i<Fishes.Length; i++)
        {
            fishScores[i] = Fishes[i].GetComponentsInChildren<Image>(); 
        }
    }
    
    public void UpdateTowerUI(int score)
    {
        for (int i=1; i<=maxTowerHealth; i++)   //RM start from 1 because first image is actually the parent itself
        {
            if (i <= score)
            {
                towerScore[i].enabled = true;
            }
            else
            {
                towerScore[i].enabled = false;
            }
        }
    }

    public void UpdateFishUI(int fishId, int fishScore)
    {
        for (int i = 1; i <= maxFishPoints; i++)   //RM start from 1 because first image is actually the parent itself
        {
            if (i <= fishScore)
            {
                fishScores[fishId][i].enabled = true;
            }
            else
            {
                fishScores[fishId][i].enabled = false;
            }
        }
    }
}
