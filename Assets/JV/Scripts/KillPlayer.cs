using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class KillPlayer : MonoBehaviour {
        void OnTriggerEnter2D (Collider2D other) {
            if (other.GetComponent<PlayerController> ()) {
                LevelManager.Instance.RespawnPlayer ();
            }
        }
    }
}
