using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JV {
    public class HashtableEvent : UnityEvent<Hashtable> { }
    public interface IEventEmitter {
        void StartListening (string eventName, UnityAction<Hashtable> listener);
        void StopListening (string eventName, UnityAction<Hashtable> listener);
        void TriggerEvent (string eventName, Hashtable eventParams = default (Hashtable));
    }

    public class EventEmitterController : MonoBehaviour, IEventEmitter {
        Dictionary<string, HashtableEvent> eventDictionary = new Dictionary<string, HashtableEvent>();

        public void StartListening (string eventName, UnityAction<Hashtable> listener) {
            HashtableEvent thisEvent = null;

            if (eventDictionary.TryGetValue (eventName, out thisEvent)) {
                thisEvent.AddListener (listener);
            } else {
                thisEvent = new HashtableEvent ();
                thisEvent.AddListener (listener);
                eventDictionary.Add (eventName, thisEvent);
            }
        }

        public void StopListening (string eventName, UnityAction<Hashtable> listener) {
            HashtableEvent thisEvent = null;

            if (eventDictionary.TryGetValue (eventName, out thisEvent)) {
                if (listener == null) {
                    thisEvent.RemoveAllListeners ();
                } else {
                    thisEvent.RemoveListener (listener);
                }
            }
        }

        public void TriggerEvent (string eventName, Hashtable eventParams = default (Hashtable)) {
            HashtableEvent thisEvent = null;

            if (eventDictionary.TryGetValue (eventName, out thisEvent)) {
                thisEvent.Invoke (eventParams);
            }
        }
    }
}

