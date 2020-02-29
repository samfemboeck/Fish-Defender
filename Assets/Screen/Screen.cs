using UnityEngine;

[CreateAssetMenu]
public class Screen : ScriptableObject
{
    [SerializeField]
    GameObject ui;

    [SerializeField]
    GameObject state;

    public GameObject UI { get => ui; set => ui = value; }
    public GameObject State { get => state; set => state = value; }
}
