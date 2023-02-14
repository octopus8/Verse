using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class O8CEventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent> eventDictionary;


    private void Awake() {
        eventDictionary = new Dictionary<string, UnityEvent>();
    }


    public void StartListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    public void StopListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public void TriggerEvent(string eventName) {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke();
        }
    }
}
