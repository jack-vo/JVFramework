using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class GenericPickup : MonoBehaviour {

        public int value;

        void OnTriggerEnter2D (Collider2D other) {
            if (other.GetComponent<PlayerController>() == null) {
                return;
            }

            ScoreManager.AddPoints (value);

            Destroy (gameObject);
        }
    }
}

