using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Projectile : MonoBehaviour {
        public PlayerController player;
        public float speed = 10f;

        protected Rigidbody2D rigidbody;

        public GameObject enemyDeathEffect;
        public GameObject impactEffect;
        public int pointsForKill;

        // Use this for initialization
        void Start () {
            player = FindObjectOfType<PlayerController> ();
            rigidbody = GetComponent<Rigidbody2D> ();

            if (player.transform.localScale.x < 0) {
                speed = -speed;
            }
        }

        void OnTriggerEnter2D (Collider2D other) {
            if (other.tag == "Enemy") {
                Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
                Destroy (other.gameObject);
                ScoreManager.AddPoints (pointsForKill);
            }

            Instantiate (impactEffect, transform.position, transform.rotation);
            Destroy (gameObject);
        }
    }
}

