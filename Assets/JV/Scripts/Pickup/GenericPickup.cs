using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class GenericPickup : MonoBehaviour {

        public AudioClip pickupAudioClip;
        public int value;

        AudioSource audioSource;

        void OnTriggerEnter2D (Collider2D other) {
            if (other.GetComponent<PlayerController>() == null) {
                return;
            }

            ScoreManager.AddPoints (value);

            if (AudioManager.AudioSourceInstance && pickupAudioClip) {
                AudioManager.AudioSourceInstance.PlayOneShot (pickupAudioClip);
            }

            Destroy (gameObject);
        }
    }
}

