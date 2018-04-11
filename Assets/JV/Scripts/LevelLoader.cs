using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JV {
    public class LevelLoader : MonoBehaviour {

        bool playerInZone;

        public string levelToLoad;

        // Update is called once per frame
        void Update () {
            if (playerInZone && Input.GetButtonDown("up")) {
                SceneManager.LoadSceneAsync (levelToLoad);
            }
        }

        void OnTriggerEnter2D (Collider2D other) {
            if (other.name == "Player") {
                playerInZone = true;
            }
        }

        void OnTriggerExit2D (Collider2D other) {
            if (other.name == "Player") {
                playerInZone = false;
            }
        }
    }
}

