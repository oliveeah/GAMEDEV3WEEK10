using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    /// <summary>
    /// Code snatched from here: https://www.raywenderlich.com/2826197-scriptableobject-tutorial-getting-started
    /// </summary>
    //This is the event S.O. we will OBSERVE
    [SerializeField] GameEvent gameEvent;
    //This will be the response executed when the event is raised
    [SerializeField] UnityEvent response;            

    private void OnEnable()
    {
        //Registers the listerner
        gameEvent.RegisterListeners(this);
    }

    private void OnDisable()
    {
        //Unregisters the listener
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        //The ? checks if response is not equal to null. If it is not, Invoke() the response.
        response?.Invoke();
    }
}
