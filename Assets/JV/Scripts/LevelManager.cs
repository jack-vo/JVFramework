using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class LevelManager : MonoBehaviour {

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
        }
    }
}
