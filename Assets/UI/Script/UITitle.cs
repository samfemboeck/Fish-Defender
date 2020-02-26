using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    [SerializeField]
    DeviceManager deviceManager;

    [SerializeField]
    Image[] fishSprites;

    [SerializeField]
    Text fishesJoinedText;

    void Start()
    {
        deviceManager = new DeviceManager();
    }

    void Update()
    {
        int gamepads = deviceManager.gamepads.Count;

        for (int i = 0; i < fishSprites.Length; i++)
        {
            if (i < gamepads)
            {
                fishSprites[i].enabled = true;
            }
            else
            {
                fishSprites[i].enabled = false;
            }
        }

        if (gamepads == 1)
            fishesJoinedText.text = gamepads + " fish joined";
        else
            fishesJoinedText.text = gamepads + " fishes joined";
    }
}
