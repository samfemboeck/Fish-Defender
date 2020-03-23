using System;
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
	private Text timerText;

    [SerializeField]
    GameObjectSet fishSet;

    [SerializeField]
    GameObjectSet towerSet;
        
    private void Start()
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
        SetupGameplayScreenTower();
    }

    //Setup displayed fishes based on joined fishes
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

    //Setup displayed initial tower score
    private void SetupGameplayScreenTower()
    {
        int score = towerSet.items[0].GetComponent<TowerScore>().Score;
        print("tower score ui:" + score);
        for (int i=0; i< towerScore.Length; i++)
        {
            if (i < score)
            {
                towerScore[i].enabled = true;
            }
            else
            {
                towerScore[i].enabled = false;
            }
        }
    }
    
    public void UpdateTowerUI(GameEvent gameEvent)
    {
        GameObject tower = gameEvent.GameObject;
        int score = tower.GetComponent<TowerScore>().Score;

        //Disable lost point
        //RM works because towers never regain points
        towerScore[score + 1].enabled = false;
    }

    public void UpdateFishUI(GameEvent gameEvent)
    {
        GameObject fish = gameEvent.GameObject;
        int id = fishSet.items.IndexOf(fish);
        int score = fish.GetComponent<FishScore>().Score;
        
        //Enable next point
        //RM works because fishes never lose points
        fishScores[id][score].enabled = true;
    }

	public void UpdateTimer(GameEvent gameEvent)
    {
		TimeSpan time = TimeSpan.FromSeconds(gameEvent.FloatData);
		string txt = time.ToString(@"mm\:ss");
		timerText.text = txt;
	}

}
