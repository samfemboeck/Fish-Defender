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

    public float fadeDuration = 1f;

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

    static public void ChangeToScreen(string screenName)
    {
        Canvas targetScreen = null;
        if (screenName == "StartScreen")
        {
            targetScreen = uiHandler.StartCanvas;
        }
        else if (screenName == "GameplayScreen")
        {
            targetScreen = uiHandler.GameplayCanvas;
        }
        else if (screenName == "EndScreen")
        {
            targetScreen = uiHandler.EndCanvas;
        }
        else
        {
            throw new System.Exception(screenName + " is not a valid Screen!");
        }

        if (targetScreen == uiHandler.currentCanvas)
        {
            return;
        }

        uiHandler.StartCoroutine(FadeCanvas(targetScreen, true));
        uiHandler.StartCoroutine(FadeCanvas(uiHandler.currentCanvas, false));
        
    }

    private static IEnumerator FadeCanvas(Canvas canvas, bool fadeIn)
    {
        CanvasGroup group = canvas.GetComponent<CanvasGroup>();
        
        if (fadeIn)
        {
            while (group.alpha + Time.deltaTime/uiHandler.fadeDuration <= 1)
            {
                group.alpha += Time.deltaTime/uiHandler.fadeDuration;
                yield return new WaitForEndOfFrame();
            }
            group.alpha = 1;
        }
        else
        {
            while (group.alpha - Time.deltaTime / uiHandler.fadeDuration >= 0)
            {
                group.alpha -= Time.deltaTime / uiHandler.fadeDuration;
                yield return new WaitForEndOfFrame();
            }
            group.alpha = 0;
        }
    }

    //StartScreen
    static public void UpdateFishesJoined(int fishCount)
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
                uiHandler.FishesJoined[i].GetComponent<Animator>().Play("Fish_wiggle", 0, Random.value);
            }
            else
            {
                uiHandler.FishesJoined[i].enabled = false;
            }
        }
    }


    //Gameplay
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
