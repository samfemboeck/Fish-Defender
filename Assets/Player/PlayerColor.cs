using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    ColorPool colorPool;

    public Color color;

    // Use this for initialization
    void Start()
    {
        color = colorPool.PickColor();
    }
}
