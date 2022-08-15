using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  These Event Listeners are the subscribers that will responds to some GameEvents
//  GameEvent is this class.

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    List<EventListener> _eventListeners = new List<EventListener>();

    public void Raise()
    {
        for(int i =0; i< _eventListeners.Count;i++)
        {
            _eventListeners[i].OnEventRaise();
        }
    }
    public void Register(EventListener listener)
    {
        if (!_eventListeners.Contains(listener))
        {
            _eventListeners.Add(listener);
        }
            
    }
    public void DeRegister(EventListener listener)
    {
        if(_eventListeners.Contains(listener))
        {
            _eventListeners.Remove(listener);
        }
    }
}


