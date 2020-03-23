using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ListenerEvent : UnityEvent<GameEvent> { }

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public ListenerEvent Response;

    private void OnEnable() { Event.RegisterListener(this); }
    private void OnDisable() { Event.UnRegisterListener(this); }

    public void OnEventRaised(GameEvent gameEvent) 
    {
        Response.Invoke(gameEvent);
    }
}
