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
        //RM TODO

        //Set image
        //RM TODO

        //Choose random fact
        int randomIndex = Random.Range(0, fishQuotes.Length - 1);
        factText.text = fishQuotes[randomIndex];
    }
}
