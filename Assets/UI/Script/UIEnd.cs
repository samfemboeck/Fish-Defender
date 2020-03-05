using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEnd : MonoBehaviour
{
    /*
     * UI Title
     * This class handles functionaltiy for the end UI.
     */

    [SerializeField]
    Image winnerImage;

    [SerializeField]
    Sprite fishSprite;

    [SerializeField]
    Sprite towerSprite;

    [SerializeField]
    string[] fishQuotes;

    [SerializeField]
    Text factText;

    [SerializeField]
    GameObjectSet towerSet;

    [SerializeField]
    GameObjectSet fishSet;

    private void Start()
    {
        //Get winner
        //Get tower score
        //int towerScore = towerSet.items[0].GetComponent<TowerScore>().Score;
        print("end tower score: " + towerSet.items.Count);
        print("end fish score: " + fishSet.items.Count);

        //Set image

        //Choose random fact
        int randomIndex = Random.Range(0, fishQuotes.Length - 1);
        factText.text = fishQuotes[randomIndex];
    }
}
