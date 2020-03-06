using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    ColorPool colorPool;

    public Color color;

    // Use this for initialization
    void Awake()
    {
        color = colorPool.PickColor();
        if (gameObject.layer == 10)
        {
            gameObject.GetComponent<towerColAssigner>().AssignMat(ColorPool.curIndex);
        }
    }
}
