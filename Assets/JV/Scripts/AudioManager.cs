using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class AudioManager : MonoBehaviour {

        private static AudioManager audioManager;
        public AudioSource audioSource;

        public static AudioManager Instance {
            get {
                if (audioManager == null) {
                    audioManager = FindObjectOfType<AudioManager> ();    
                }

                return audioManager;
            }
        }

        public static AudioSource AudioSourceInstance {
            get {
                if (Instance.audioSource == null) {
                    Instance.audioSource = Instance.gameObject.AddComponent<AudioSource> ();
                }

                return Instance.audioSource;
            }
        }

        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {

        }
    }
}

