using UnityEngine;

public class RuntimeTrackable : MonoBehaviour
{
    [SerializeField]
    GameObjectSet set;

    void OnEnable()
    {
        set.Add(gameObject);
    }

    void OnDisable()
    {
        set.Remove(gameObject);
    }
}
