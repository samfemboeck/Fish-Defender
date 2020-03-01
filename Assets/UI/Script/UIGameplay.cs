using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [SerializeField]
    Image towerImage;
    private Image[] towerScore;

    [SerializeField]
    Image[] fishImages = new Image[8];
    private Image[][] fishScores;

    [SerializeField]
    GameObjectSet fishSet;

    int maxTowerHealth = 10;    //RM need to be adjustes when balancing feat got implemented
    int maxFishPoints = 10;
    
    private void Awake()
    {
        //Get Tower Point images
        towerScore = towerImage.GetComponentsInChildren<Image>();

        //Get Fish point images
        fishScores = new Image[fishImages.Length][];
        for (int i=0; i<fishImages.Length; i++)
        {
            fishScores[i] = fishImages[i].GetComponentsInChildren<Image>(); 
        }

        //Setup
        SetupGameplayScreenFishes();
    }

    private void SetupGameplayScreenFishes()
    {
        //Iterate fish set and set color of images on UI
        for (int i=0; i<fishSet.Count; i++)
        {
            Color playerColor = fishSet.items[i].gameObject.GetComponent<PlayerColor>().color;
            fishImages[i].color = playerColor;
        }
        //Disable unused sprites
        for (int i=fishSet.Count; i<fishImages.Length; i++)
        {
            fishImages[i].enabled = false;
        }
    }
    
    public void UpdateTowerUI(GameObject tower)
    {
        int score = tower.GetComponent<TowerScore>().Score;

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
