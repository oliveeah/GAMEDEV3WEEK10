using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Game Event", menuName = "Scriptable Objects/Game Event")]
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// Code snatched from here: https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started
    /// </summary>

    //Will store all the listeners in this variable
    private List<GameEventListener> listeners = new List<GameEventListener>();


    //The Raise() method will tell all the subscribers to Invoke() their response.
    //It is basically a way to say "Hello! If you are subscribed, it is time to execute the event you wanted to..."
    public void Raise()
    {
        //It goes through all the listeners, and notifies
        //them that the event has been raise
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListeners(GameEventListener listener)
    {
        listeners.Add(listener);

    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
