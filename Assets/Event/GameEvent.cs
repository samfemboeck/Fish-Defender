using UnityEngine;
using System.Collections.Generic;

// You can create events in the editor with right click -> create
[CreateAssetMenu(menuName="GameEvent", fileName="GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise(GameObject go)
    {
        // iterate backwards so listeners can UnRegisterListener() in OnEventRaised()
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(go);
        }
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
