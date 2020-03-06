using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour
{
    public Color color;

    [SerializeField]
    private ColorPool colorPool;

    private void OnEnable()
    {
        color = colorPool.Get();
    }

    private void OnDisable()
    {
        color = colorPool.PickColor();
        if (gameObject.layer == 10)
        {
            gameObject.GetComponent<towerColAssigner>().AssignMat(ColorPool.curIndex);
        }
    }
}
