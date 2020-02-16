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


    //Var
    Canvas currentCanvas;

    public Image Tower;
    private Image[] towerScore;

    public Image[] Fishes = new Image[8];
    private Image[][] fishScores;

    static UiHandler uiHandler;


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

    static public void UpdateTowerUI(int towerScore)
    {
        for (int i=1; i<=10; i++)   //RM start from 1 because first image is actually the parent itself
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
        print("update fish ui " + fishId + " - " + fishScore);
        for (int i = 1; i <= 10; i++)   //RM start from 1 because first image is actually the parent itself
        {
            if (i <= fishScore)
            {
                print(i + " - " + uiHandler.fishScores[fishId][i].gameObject.name + " enabled");
                uiHandler.fishScores[fishId][i].enabled = true;
            }
            else
            {
                print(i + " - " + uiHandler.fishScores[fishId][i].gameObject.name + " disabled");
                uiHandler.fishScores[fishId][i].enabled = false;
            }
        }
    }

}
