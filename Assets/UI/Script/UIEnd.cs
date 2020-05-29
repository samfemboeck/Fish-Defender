using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEnd : MonoBehaviour
{
    [SerializeField]
    Image[] winnerImages;

    [SerializeField]
    Sprite fishSprite;

    [SerializeField]
    Sprite towerSprite;

    [SerializeField]
    string[] fishQuotes;

    [SerializeField]
    Text factText;

    private void Start()
    {
        int randomIndex = Random.Range(0, fishQuotes.Length - 1);
        factText.text = fishQuotes[randomIndex];
    }

    public void SetWinnerSprite(StateEnd endState)
    {
        if (endState.fishWin)
        {
            for (int i=0; i<winnerImages.Length; i++)
            {
                if (i < endState.winnerColor.Length)
                {
                    winnerImages[i].sprite = fishSprite;
                    winnerImages[i].enabled = true;
                    winnerImages[i].GetComponent<Animator>().Play("Fish_wiggle", 0, Random.value);
                    winnerImages[i].color = endState.winnerColor[i];
                }
                else
                {
                    winnerImages[i].enabled = false;
                }
            }
        }
        else
        {
            winnerImages[0].sprite = towerSprite;
            winnerImages[0].enabled = true;
            winnerImages[0].color = Color.white;
            for (int i=1; i<winnerImages.Length; i++)
            {
                winnerImages[i].enabled = false;
            }
        }
        
    }
}
