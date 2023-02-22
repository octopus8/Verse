using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Provides "event" functionality.
/// </summary>
public class O8CEventManager : MonoBehaviour
{
    #region Class Variables

    /// <summary>The collection of events.</summary>
    private Dictionary<string, UnityEvent> eventDictionary;

    #endregion



    #region Base Methods

    /// <summary>
    /// Initializes variables.
    /// </summary>
    private void Awake() {
        eventDictionary = new Dictionary<string, UnityEvent>();
    }

    #endregion



    #region Public Methods

    /// <summary>
    /// Registers an event listener.
    /// </summary>
    /// <param name="eventName">Key for the event.</param>
    /// <param name="listener">Event handler</param>
    public void StartListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        } else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(eventName, thisEvent);
        }
    }


    /// <summary>
    /// Unregisters an event listener.
    /// </summary>
    /// <param name="eventName">Key for the event.</param>
    /// <param name="listener">Event handler</param>
    public void StopListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }


    /// <summary>
    /// Triggers an event.
    /// </summary>
    /// <param name="eventName">The key for the event to trigger.</param>
    public void TriggerEvent(string eventName) {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke();
        }
    }

    #endregion

}
