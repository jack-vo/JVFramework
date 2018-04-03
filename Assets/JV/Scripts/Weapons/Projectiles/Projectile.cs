using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Projectile : MonoBehaviour {
        public PlayerController player;
        public float speed = 10f;

        protected Rigidbody2D rigidbody;

        // Use this for initialization
        void Start () {
            player = FindObjectOfType<PlayerController> ();
            rigidbody = GetComponent<Rigidbody2D> ();

            if (player.transform.localScale.x < 0) {
                speed = -speed;
            }
        }

        void OnTriggerEnter2D (Collider2D collision) {
            Destroy (gameObject);
        }
    }
}

