using UnityEngine;
using System.Collections.Generic;

// You can create events in the editor with right click -> create
[CreateAssetMenu(menuName="GameEvent", fileName="GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    public GameObject GameObject { get; set; }
    public float FloatData { get; set; }

    public void Raise()
    {
        // iterate backwards so listeners can UnRegisterListener() in OnEventRaised()
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(this);
        }
    }

    public void Raise(GameObject gameObject)
    {
        GameObject = gameObject;
        Raise();
    }

    public void Raise(float f)
    {
        FloatData = f;
        Raise();
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
