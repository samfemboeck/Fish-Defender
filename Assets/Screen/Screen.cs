using UnityEngine;

[CreateAssetMenu]
public class Screen : ScriptableObject, IScreen
{
    [SerializeField]
    GameObject ui;

    [SerializeField]
    GameObject state;

    GameObject IScreen.UI { get => ui; set => ui = value; }
    GameObject IScreen.State { get => state; set => state = value; }
}
