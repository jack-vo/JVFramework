using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JV {
    public class HashtableEvent : UnityEvent<Hashtable> { }

    public class LevelManager : MonoBehaviour {

        private Dictionary<string, HashtableEvent> eventDictionary;
        private static LevelManager levelManager;

        public static LevelManager Instance {
            get {
                if (!levelManager) {
                    levelManager = FindObjectOfType<LevelManager> ();

                    if (!levelManager) {
                        Debug.Log("There needs to be one active LevelManager script on a GameObject in your scene.");
                    } else {
                        levelManager.Init ();
                    }
                }

                return levelManager;
            }
        }

        void Init () {
            if (eventDictionary == null) {
                eventDictionary = new Dictionary<string, HashtableEvent> ();
            }
        }

        public static void StartListening(string eventName, UnityAction<Hashtable> listener) {
            HashtableEvent thisEvent = null;

            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
                thisEvent.AddListener (listener);
            } else {
                thisEvent = new HashtableEvent ();
                thisEvent.AddListener (listener);
                Instance.eventDictionary.Add (eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction<Hashtable> listener) {
            HashtableEvent thisEvent = null;

            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
                if (listener == null) {
                    thisEvent.RemoveAllListeners ();
                } else {
                    thisEvent.RemoveListener (listener);
                }
            }
        }

        public static void TriggerEvent (string eventName, Hashtable eventParams = default(Hashtable)) {
            HashtableEvent thisEvent = null;

            if (Instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
                thisEvent.Invoke (eventParams);
            }
        }

        public static void TriggerEvent (string eventName) {
            TriggerEvent (eventName, null);
        }

        public GameObject currentCheckpoint;

        public GameObject deathParticle;
        public GameObject respawnParticle;
        public float respawnDelay = 2f;

        public int pointPernaltyOnDeath;

        private bool respawningPlayer;
        private PlayerController player;
        private CameraController camera;

        void Start () {
            player = FindObjectOfType<PlayerController> ();
            camera = FindObjectOfType<CameraController> ();
        }

        public void RespawnPlayer() {
            if (respawningPlayer) {
                return;
            }

            respawningPlayer = true;
            StartCoroutine ("RespawnPlayerCo");
        }

        public IEnumerator RespawnPlayerCo () {
            Instantiate (deathParticle, player.transform.position, player.transform.rotation);
            player.SetEnabled (false);
            camera.isFollowing = false;
            ScoreManager.AddPoints (-pointPernaltyOnDeath);

            Debug.Log ("Respawn player");

            yield return new WaitForSeconds (respawnDelay);

            Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
            player.transform.position = currentCheckpoint.transform.position;
            player.SetEnabled (true);
            camera.isFollowing = true;
            respawningPlayer = false;


            PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();

            if (playerHealth != null) {
                playerHealth.FullHealth ();
            }
        }
    }
}
