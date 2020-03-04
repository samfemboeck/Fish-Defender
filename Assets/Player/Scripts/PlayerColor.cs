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
        colorPool.Return(color);
    }
}
