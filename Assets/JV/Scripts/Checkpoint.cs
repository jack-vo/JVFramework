using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Checkpoint : MonoBehaviour {
        protected LevelManager levelManager;

        private void Start () {
            levelManager = FindObjectOfType<LevelManager> ();
        }

        void OnTriggerEnter2D (Collider2D other) {
            if (other.GetComponent<PlayerController> ()) {
                levelManager.currentCheckpoint = gameObject;
            }
        }
    }
}
