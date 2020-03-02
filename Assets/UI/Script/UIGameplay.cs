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

    public void SetupGameplayScreenTower()
    {
        //TODO
        //After points based on fish count got implemented
    }
    
    public void UpdateTowerUI(GameObject tower)
    {
        int score = tower.GetComponent<TowerScore>().Score;

        //Disable lost point
        //RM works because towers never regain points
        towerScore[score + 1].enabled = false;
    }

    public void UpdateFishUI(GameObject fish)
    {
        int id = fishSet.items.IndexOf(fish);
        int score = fish.GetComponent<FishScore>().Score;
        
        //Enable next point
        //RM works because fishes never lose points
        fishScores[id][score].enabled = true;
    }
}
