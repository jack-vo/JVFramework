using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class KillPlayer : MonoBehaviour {
        public LevelManager levelManager;

        void Start () {
            levelManager = FindObjectOfType<LevelManager> ();
        }

        void OnTriggerEnter2D (Collider2D other) {
            if (other.GetComponent<PlayerController> ()) {
                levelManager.RespawnPlayer ();
            }
        }
    }
}
