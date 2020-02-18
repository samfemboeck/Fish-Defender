using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{

    //References
    public Canvas StartCanvas;
    public Canvas GameplayCanvas;
    public Canvas EndCanvas;

    Canvas currentCanvas;

    //Start Menu
    public Text FishesJoinedText;

    public Image[] FishesJoined = new Image[8];

    static int currentFishCount = -1;

    //Gameplay
    public Image Tower;
    private Image[] towerScore;

    public Image[] Fishes = new Image[8];
    private Image[][] fishScores;

    static UiHandler uiHandler;

    public int maxTowerHealth = 10;
    public int maxFishPoints = 10;


    //Functions
    private void Awake()
    {
        currentCanvas = StartCanvas;

        uiHandler = this;

        //Get Tower Point images
        towerScore = Tower.GetComponentsInChildren<Image>();

        //Get Fish point images
        fishScores = new Image[Fishes.Length][];
        for(int i=0; i<Fishes.Length; i++)
        {
            fishScores[i] = Fishes[i].GetComponentsInChildren<Image>(); 
        }
    }

    static public void UpdateFishesJoinedText(int fishCount)
    {
        //Check whether fishCount did change
        if (fishCount == UiHandler.currentFishCount)
        {
            return;
        }

        UiHandler.currentFishCount = fishCount;

        //Update Text
        if (fishCount == 1)
        {
            uiHandler.FishesJoinedText.text = fishCount + " fish joined";
        }
        else
        {
            uiHandler.FishesJoinedText.text = fishCount + " fishes joined";
        }

        //Update UI display
        for (int i=0; i<uiHandler.FishesJoined.Length; i++)
        {
            if (i < fishCount)
            {
                uiHandler.FishesJoined[i].enabled = true;
                uiHandler.FishesJoined[i].GetComponent<Animator>().enabled = true;
            }
            else
            {
                uiHandler.FishesJoined[i].enabled = false;
            }
        }
    }

    static public void UpdateTowerUI(int towerScore)
    {
        for (int i=1; i<=uiHandler.maxTowerHealth; i++)   //RM start from 1 because first image is actually the parent itself
        {
            if (i <= towerScore)
            {
                uiHandler.towerScore[i].enabled = true;
            }
            else
            {
                uiHandler.towerScore[i].enabled = false;
            }
        }
    }

    static public void UpdateFishUI(int fishId, int fishScore)
    {
        for (int i = 1; i <= uiHandler.maxFishPoints; i++)   //RM start from 1 because first image is actually the parent itself
        {
            if (i <= fishScore)
            {
                uiHandler.fishScores[fishId][i].enabled = true;
            }
            else
            {
                uiHandler.fishScores[fishId][i].enabled = false;
            }
        }
    }

}
